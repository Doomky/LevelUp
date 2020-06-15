using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using static LevelUpAPI.Helpers.ClaimsHelpers;
using QuestState = LevelUpAPI.DataAccess.QuestHandlers.Interfaces.IQuestHandler.QuestState;
using static LevelUpAPI.DataAccess.QuestHandlers.Interfaces.IQuestHandler;
using LevelUpAPI.DataAccess.QuestHandlers;

namespace LevelUpAPI.RequestHandlers
{
    public class GetQuestRequestHandler : RequestHandler<GetQuestRequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly IQuestRepository _questRepository;
        private readonly IQuestTypeRepository _questTypeRepository;
        private readonly QuestState? _questState = null;

        public GetQuestRequestHandler(IUserRepository userRepository, IQuestRepository questRepository, IQuestTypeRepository questTypeRepository, QuestState? questState)
        {
            _userRepository = userRepository;
            _questRepository = questRepository;
            _questTypeRepository = questTypeRepository;
            _questState = questState;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(Request, context, _userRepository);
            if (!isOk || user == null)
                return;

            var quests = _questRepository.Get(user, _questTypeRepository, _questState)
                .GetAwaiter().GetResult()
                .Select(quest => new
                {
                    quest.Id,
                    quest.CategoryId,
                    quest.TypeId,
                    quest.UserId,
                    quest.CreationDate,
                    quest.ExpirationDate,
                    quest.ProgressValue,
                    quest.ProgressCount,
                    quest.XpValue,
                    State = QuestHandlers.Create(quest, _questTypeRepository).GetState().ToString()
            });

            string questsJson = JsonSerializer.Serialize(quests);
            context.Response.StatusCode = StatusCodes.Status200OK;
            context.Response.WriteAsync(questsJson).GetAwaiter().GetResult();
        }
    }
}
