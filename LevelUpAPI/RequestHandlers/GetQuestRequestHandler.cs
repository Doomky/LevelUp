using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using static LevelUpAPI.Helpers.ClaimsHelpers;
using QuestState = LevelUpAPI.DataAccess.QuestHandlers.Interfaces.IQuestHandler.QuestState;

namespace LevelUpAPI.RequestHandlers
{
    public class GetQuestRequestHandler : RequestHandler<GetQuestDTORequest, GetQuestDTOResponse>
    {
        private readonly QuestState? _questState = null;
        private readonly IUserRepository _userRepository;
        private readonly IQuestRepository _questRepository;
        private readonly IQuestTypeRepository _questTypeRepository;

        public GetQuestRequestHandler(QuestState? questState, ClaimsPrincipal claims, GetQuestDTORequest dTORequest, ILogger logger, IUserRepository userRepository, IQuestRepository questRepository, IQuestTypeRepository questTypeRepository) : base(claims, dTORequest,logger)
        {
            _questState = questState;
            _userRepository = userRepository;
            _questRepository = questRepository;
            _questTypeRepository = questTypeRepository;
        }

        protected override async Task<(GetQuestDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            (User user, HttpStatusCode statusCode, string err) = CheckClaimsForUser(DTORequest, Claims, _userRepository);
            if (user == null)
                return (null, statusCode, err);

            IEnumerable<Quest> quests = await _questRepository.Get(user, _questTypeRepository, _questState);

            string questsJson = JsonSerializer.Serialize(quests);

            List<GetQuestDTOResponse.QuestDTOResponse1> questDTOResponses = quests
                .Select(q => new GetQuestDTOResponse.QuestDTOResponse1(
                    q.Id,
                    q.CategoryId,
                    q.TypeId,
                    q.ProgressValue,
                    q.ProgressCount,
                    q.UserId,
                    q.XpValue,
                    q.CreationDate,
                    q.ExpirationDate,
                    q.IsClaimed)).ToList();
            return (new GetQuestDTOResponse(questDTOResponses), HttpStatusCode.OK, null);
        }
    }
}
