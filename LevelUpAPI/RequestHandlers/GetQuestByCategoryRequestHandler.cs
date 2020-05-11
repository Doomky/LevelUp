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
    public class GetQuestByCategoryRequestHandler : RequestHandler<GetQuestByCategoryRequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly IQuestRepository _questRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly string _categoryName;
        
        public GetQuestByCategoryRequestHandler(IUserRepository userRepository, IQuestRepository questRepository, ICategoryRepository categoryRepository, string categoryName)
        {
            _userRepository = userRepository;
            _questRepository = questRepository;
            _categoryRepository = categoryRepository;
            _categoryName = categoryName; 
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

            Category category = _categoryRepository.GetByName(_categoryName).GetAwaiter().GetResult();
            if (category == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.WriteAsync("the category does not exit").GetAwaiter().GetResult();
                return;
            }

            IEnumerable<Quest> quests = _questRepository.Get(user, category.Id).GetAwaiter().GetResult();
            string questsJson = JsonSerializer.Serialize(quests);
            context.Response.StatusCode = StatusCodes.Status200OK;
            context.Response.WriteAsync(questsJson).GetAwaiter().GetResult();
        }
    }
}
