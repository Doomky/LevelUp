using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class GetQuestByCategoryRequestHandler : RequestHandler<GetQuestByCategoryRequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly IQuestRepository _questRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IQuestTypeRepository _questTypeRepository;
        private readonly string _categoryName;

        public GetQuestByCategoryRequestHandler(IUserRepository userRepository, IQuestRepository questRepository, ICategoryRepository categoryRepository, IQuestTypeRepository questTypeRepository, string categoryName)
        {
            _userRepository = userRepository;
            _questRepository = questRepository;
            _categoryRepository = categoryRepository;
            _questTypeRepository = questTypeRepository;
            _categoryName = categoryName;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(Request, context, _userRepository);
            if (!isOk || user == null)
                return;

            Category category = _categoryRepository.GetByName(_categoryName).GetAwaiter().GetResult();
            if (category == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.WriteAsync("the category does not exit").GetAwaiter().GetResult();
                return;
            }

            IEnumerable<Quest> quests = _questRepository.Get(user, category.Id, _questTypeRepository).GetAwaiter().GetResult();
            string questsJson = JsonSerializer.Serialize(quests);
            context.Response.StatusCode = StatusCodes.Status200OK;
            context.Response.WriteAsync(questsJson).GetAwaiter().GetResult();
        }
    }
}
