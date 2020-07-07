using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using static LevelUpDTO.GetQuestCategoriesDTOResponse;

namespace LevelUpAPI.RequestHandlers
{
    public class GetQuestCategoriesRequestHandler : RequestHandler<GetQuestCategoriesDTORequest, GetQuestCategoriesDTOResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetQuestCategoriesRequestHandler(ClaimsPrincipal claims, GetQuestCategoriesDTORequest dTORequest, ILogger logger, ICategoryRepository categoryRepository) : base(claims, dTORequest, logger)
        {
            _categoryRepository = categoryRepository;
        }

        protected async override Task<(GetQuestCategoriesDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            IEnumerable<Category> categories = _categoryRepository.GetAllCategories();

            if (categories == null)
                return (null, HttpStatusCode.BadRequest, null);

            List<CategoryDTOResponse> categoriesDTOs = categories.Select( category =>
                new CategoryDTOResponse(category.Id, category.Name)
            ).ToList();

            GetQuestCategoriesDTOResponse dtoReponse = new GetQuestCategoriesDTOResponse(categoriesDTOs);

            return (dtoReponse, HttpStatusCode.OK, null);
        }
    }
}
