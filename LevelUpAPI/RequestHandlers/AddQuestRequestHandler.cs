using LevelUpAPI.DataAccess.Quests;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LevelUpAPI.RequestHandlers
{
    public class AddQuestRequestHandler : RequestHandler<AddQuestRequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly IQuestRepository _questRepository;
        private readonly IQuestTypeRepository _questTypeRepository;
        private readonly ICategoryRepository _categoryRepository;

        public AddQuestRequestHandler(IUserRepository userRepository, IQuestRepository questRepository, IQuestTypeRepository questTypeRepository, ICategoryRepository categoryRepository)
        {
            _userRepository = userRepository;
            _questRepository = questRepository;
            _questTypeRepository = questTypeRepository;
            _categoryRepository = categoryRepository;
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

            Quest quest = Quests.Create(Request, user, _questTypeRepository, _categoryRepository).GetAwaiter().GetResult();

            quest = _questRepository.Insert(quest).GetAwaiter().GetResult();

            context.Response.StatusCode = StatusCodes.Status200OK;
        }
    }
}
