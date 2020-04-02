using LevelUpAPI.DataAccess.OpenFoodFacts.Product;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.RequestHandlers
{
    public class GetOFFDataFromCategoryRequestHandler : RequestHandler<GetOFFDataFromCategoryRequest>
    {
        private readonly IOFFDatasCategoryRepository _oFFDatasCategoryRepository;
        private readonly string categoryName;

        public GetOFFDataFromCategoryRequestHandler(IOFFDatasCategoryRepository oFFDatasCategoryRepository, string categoryName)
        {
            _oFFDatasCategoryRepository = oFFDatasCategoryRepository;
            this.categoryName = categoryName;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            var dataCategories = _oFFDatasCategoryRepository.GetByCategoryName(categoryName).GetAwaiter().GetResult();
        }
    }
}
