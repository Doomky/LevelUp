using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace LevelUpAPI.RequestHandlers
{
    public class GetOFFDataFromCategoryRequestHandler : RequestHandler<GetOFFDataFromCategoryDTORequest, GetOFFDataFromCategoryDTOResponse>
    {
        private readonly IOFFDatasCategoryRepository _oFFDatasCategoryRepository;
        private readonly string _categoryName;

        public GetOFFDataFromCategoryRequestHandler(IOFFDatasCategoryRepository oFFDatasCategoryRepository, string categoryName)
        {
            _oFFDatasCategoryRepository = oFFDatasCategoryRepository;
            _categoryName = categoryName;
        }

        protected override async Task<GetOFFDataFromCategoryDTOResponse> ExecuteRequest(HttpContext context)
        {
            if (DTORequest == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return null;
            }

            OpenFoodFactsDatasCategory openFoodFactsDataCategory = _oFFDatasCategoryRepository.GetByCategoryName(_categoryName).GetAwaiter().GetResult();

            if (openFoodFactsDataCategory != null)
            {
                OpenFoodFactsData openFoodFactsData = _oFFDatasCategoryRepository.GetOFFDataByOFFCategory(openFoodFactsDataCategory).GetAwaiter().GetResult();
                if (openFoodFactsData != null)
                {
                    string openFoodFactsDataCategoryJson = JsonSerializer.Serialize(openFoodFactsData);
                    context.Response.StatusCode = StatusCodes.Status200OK;
                    context.Response.WriteAsync(openFoodFactsDataCategoryJson).GetAwaiter().GetResult();
                    return JsonSerializer.Deserialize<GetOFFDataFromCategoryDTOResponse>(openFoodFactsDataCategoryJson);
                }
            }
            context.Response.StatusCode = StatusCodes.Status204NoContent;
            return null;
        }
    }
}
