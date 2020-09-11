using LevelUpAPI.DataAccess.Repositories;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO.Requests;
using LevelUpDTO.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using static LevelUpAPI.DataAccess.QuestHandlers.Interfaces.IQuestHandler;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class GetAdviceByCategoryRequestHandler : RequestHandler<GetAdviceByCategoryDTORequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAdviceRepository _adviceRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly string _categoryName;

        public GetAdviceByCategoryRequestHandler(IUserRepository userRepository, IAdviceRepository adviceRepository, ICategoryRepository categoryRepository, string categoryName)
        {
            _userRepository = userRepository;
            _adviceRepository = adviceRepository;
            _categoryRepository = categoryRepository;
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
            
            Advice advice = _adviceRepository.GetByCategoryForUser(category, user).GetAwaiter().GetResult();

            AdivceDTOResponse adivceDTOResponse = new AdivceDTOResponse() {
                Id = advice.Id,
                Category = category.Name,
                Text = advice.Text
            };

            string adviceJson = JsonSerializer.Serialize(adivceDTOResponse);
            context.Response.StatusCode = StatusCodes.Status200OK;
            context.Response.WriteAsync(adviceJson).GetAwaiter().GetResult();
        }

    }
}
