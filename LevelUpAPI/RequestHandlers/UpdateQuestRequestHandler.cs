using LevelUpAPI.DataAccess.QuestHandlers;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using static LevelUpAPI.DataAccess.QuestHandlers.Interfaces.IQuestHandler;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class UpdateQuestRequestHandler : RequestHandler<UpdateQuestDTORequest, UpdateQuestDTOResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IQuestRepository _questRepository;
        private readonly IQuestTypeRepository _questTypeRepository;

        public UpdateQuestRequestHandler(
            IUserRepository userRepository,
            IQuestRepository questRepository,
            IQuestTypeRepository questTypeRepository,
            ClaimsPrincipal claims,
            UpdateQuestDTORequest dTORequest,
            ILogger logger)
            : base(claims, dTORequest, logger)
        {
            _userRepository = userRepository;
            _questRepository = questRepository;
            _questTypeRepository = questTypeRepository;
        }

        protected override async Task<(UpdateQuestDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            (User user, HttpStatusCode statusCode, string err) = CheckClaimsForUser(DTORequest, Claims, _userRepository);
            if (user == null)
                return (null, statusCode, err);

            IEnumerable<Quest> quests = _questRepository.Get(user, _questTypeRepository, QuestState.InProgress).GetAwaiter().GetResult();
            foreach (Quest quest in quests)
            {
                QuestHandler questHandler = QuestHandlers.Create(quest, user, _questTypeRepository);
                if (questHandler != null)
                {
                    questHandler.Update(DTORequest);
                    _questRepository.Update(quest).GetAwaiter().GetResult();
                }
            }

            var questsDtoResponse = (IEnumerable<UpdateQuestDTOResponse.Quest>) quests;
            return (new UpdateQuestDTOResponse(questsDtoResponse), HttpStatusCode.OK, null);
        }
    }
}
