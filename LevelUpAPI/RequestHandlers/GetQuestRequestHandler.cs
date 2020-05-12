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

namespace LevelUpAPI.RequestHandlers
{
    public class GetQuestRequestHandler : RequestHandler<GetQuestRequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly IQuestRepository _questRepository;

        public GetQuestRequestHandler(IUserRepository userRepository, IQuestRepository questRepository)
        {
            _userRepository = userRepository;
            _questRepository = questRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            if (Request == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }

            ClaimsPrincipal claims = context.User;
            
            if (claims == null)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.WriteAsync("no claims").GetAwaiter().GetResult();
                return;
            }

            User user = _userRepository.GetUserByClaims(claims).GetAwaiter().GetResult();

            if (user == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.WriteAsync("no user for this client_id").GetAwaiter().GetResult();
                return;
            }

            IEnumerable<Quest> quests = _questRepository.Get(user).GetAwaiter().GetResult();

            string questsJson = JsonSerializer.Serialize(quests);
            context.Response.StatusCode = StatusCodes.Status200OK;
            context.Response.WriteAsync(questsJson).GetAwaiter().GetResult();
        }
    }
}
