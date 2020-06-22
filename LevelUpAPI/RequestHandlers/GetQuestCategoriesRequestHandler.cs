using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace LevelUpAPI.RequestHandlers
{
    public class GetQuestCategoriesRequestHandler : RequestHandler<GetQuestCategoriesRequest>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetQuestCategoriesRequestHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            IEnumerable<Category> categories = _categoryRepository.GetAllCategories();

            if (categories != null)
            {
                string categoriesJson = JsonSerializer.Serialize(categories);
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.WriteAsync(categoriesJson).GetAwaiter().GetResult();
            }
            else
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}
