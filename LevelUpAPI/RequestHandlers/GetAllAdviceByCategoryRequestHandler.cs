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
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class GetAllAdviceByCategoryRequestHandler : RequestHandler<GetAllAdvicesByCategoryDTORequest>
    {
        private readonly IAdviceRepository _adviceRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly string _categoryName;

        public GetAllAdviceByCategoryRequestHandler(IAdviceRepository adviceRepository, IUserRepository userRepository, ICategoryRepository categoryRepository, string categoryName)
        {
            _adviceRepository = adviceRepository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            _categoryName = categoryName;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(Request, context, _userRepository);
            if (!isOk || user == null)
                return;
            Advice[] advices = null;
            string adviceJson = null;

            Category category = _categoryRepository.GetByName(Request.Category).GetAwaiter().GetResult();

            advices = _adviceRepository.GetAllByCategoryForUser(category, user).GetAwaiter().GetResult();

            List<AdivceDTOResponse> adivcesDTOResponse = advices.Select((advice)=> new AdivceDTOResponse()
            {
                Id = advice.Id,
                Category = category.Name,
                Text = advice.Text
            }).ToList();

            adviceJson = JsonSerializer.Serialize(adivcesDTOResponse);

            context.Response.StatusCode = StatusCodes.Status200OK;
            context.Response.WriteAsync(adviceJson).GetAwaiter().GetResult();
        }
    }
}
