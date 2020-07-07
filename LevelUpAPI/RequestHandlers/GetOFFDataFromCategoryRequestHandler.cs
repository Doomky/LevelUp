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

namespace LevelUpAPI.RequestHandlers
{
    public class GetOFFDataFromCategoryRequestHandler : RequestHandler<GetOFFDataFromCategoryDTORequest, GetOFFDataFromCategoryDTOResponse>
    {
        private readonly IOFFDatasCategoryRepository _oFFDatasCategoryRepository;
        private readonly string _categoryName;

        public GetOFFDataFromCategoryRequestHandler(ClaimsPrincipal claims, GetOFFDataFromCategoryDTORequest dtoRequest, ILogger logger, IOFFDatasCategoryRepository oFFDatasCategoryRepository, string categoryName) : base(claims, dtoRequest, logger)
        {
            _oFFDatasCategoryRepository = oFFDatasCategoryRepository;
            _categoryName = categoryName;
        }

        protected async override Task<(GetOFFDataFromCategoryDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            if (DTORequest == null)
                return (null, HttpStatusCode.BadRequest, null);

            OpenFoodFactsDatasCategory openFoodFactsDataCategory = await _oFFDatasCategoryRepository.GetByCategoryName(_categoryName);

            if (openFoodFactsDataCategory == null)
                return (null, HttpStatusCode.NoContent, null);

            OpenFoodFactsData openFoodFactsData = await _oFFDatasCategoryRepository.GetOFFDataByOFFCategory(openFoodFactsDataCategory);

            GetOFFDataFromCategoryDTOResponse dtoResponse = new GetOFFDataFromCategoryDTOResponse(
                openFoodFactsData.Id,
                openFoodFactsData.Code,
                openFoodFactsData.Name,
                openFoodFactsData.Energy100g,
                openFoodFactsData.Sodium100g,
                openFoodFactsData.Salt100g,
                openFoodFactsData.Fat100g,
                openFoodFactsData.SaturatedFat100g,
                openFoodFactsData.Proteins100g,
                openFoodFactsData.Sugars100g,
                openFoodFactsData.EnergyServing,
                openFoodFactsData.SodiumServing,
                openFoodFactsData.SaltServing,
                openFoodFactsData.FatServing,
                openFoodFactsData.SaturatedFatServing,
                openFoodFactsData.ProteinsServing,
                openFoodFactsData.SugarsServing,
                openFoodFactsData.ImgUrl,
                openFoodFactsData.IsCustom
            );

            return (dtoResponse, HttpStatusCode.OK, null);
        }
    }
}
