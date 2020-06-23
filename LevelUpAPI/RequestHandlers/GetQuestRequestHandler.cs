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

            IEnumerable<Quest> quests = _questRepository.Get(user, _questTypeRepository, _questState).GetAwaiter().GetResult();

            string questsJson = JsonSerializer.Serialize(quests);
            context.Response.StatusCode = StatusCodes.Status200OK;
            context.Response.WriteAsync(questsJson).GetAwaiter().GetResult();
        }
    }
}
