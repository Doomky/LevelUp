using LevelUpAPI.DataAccess.QuestHandlers;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static LevelUpAPI.DataAccess.QuestHandlers.Interfaces.IQuestHandler;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class UpdateQuestRequestHandler : RequestHandler<UpdateQuestRequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly IQuestRepository _questRepository;
        private readonly IQuestTypeRepository _questTypeRepository;

        public UpdateQuestRequestHandler(IUserRepository userRepository, IQuestRepository questRepository, IQuestTypeRepository questTypeRepository) : base()
        {
            _userRepository = userRepository;
            _questRepository = questRepository;
            _questTypeRepository = questTypeRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(Request, context, _userRepository);
            if (!isOk || user == null)
                return;

            IEnumerable<Quest> quests = _questRepository.Get(user).GetAwaiter().GetResult();
            foreach (Quest quest in quests)
            {
                QuestHandler questHandler = QuestHandlers.Create(quest, _questTypeRepository);
                if (questHandler != null)
                {
                    switch (questHandler.Update(Request))
                    {
                        case QuestState.InProgress:
                            break;
                        case QuestState.Failed:
                            break;
                        case QuestState.Finished:
                            break;
                        default:
                            break;
                    }
                    _questRepository.Update(quest).GetAwaiter().GetResult();
                }
            }
            context.Response.StatusCode = StatusCodes.Status200OK;
        }
    }
}
