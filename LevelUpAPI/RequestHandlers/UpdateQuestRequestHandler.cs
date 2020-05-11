using LevelUpAPI.DataAccess.QuestHandlers;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using static LevelUpAPI.DataAccess.QuestHandlers.Interfaces.IQuestHandler;

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
            ClaimsPrincipal claims = context.User;

            if (claims == null)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.WriteAsync("no claims").GetAwaiter().GetResult();
                return;
            }

            Dbo.User user = _userRepository.GetUserByClaims(claims).GetAwaiter().GetResult();

            if (user == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.WriteAsync("no user for this client_id").GetAwaiter().GetResult();
                return;
            }
            
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
        }
    }
}
