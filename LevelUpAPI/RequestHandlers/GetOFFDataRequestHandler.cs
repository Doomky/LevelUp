using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpAPI.Dbo.OpenFoodFacts;
using LevelUpDTO;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LevelUpAPI.RequestHandlers
{
    public class GetOFFDataRequestHandler : RequestHandler<GetOFFDataDTORequest, GetOFFDataDTOResponse>
    {
        private readonly string _barcode;
        private readonly IOFFDataRepository _OFFDataRepository;
        private readonly IOFFCategoryRepository _OFFCategoryRepository;
        private readonly IOFFDatasCategoryRepository _OFFDatasCategoryRepository;

        public GetOFFDataRequestHandler(ClaimsPrincipal claims, GetOFFDataDTORequest dTORequest, ILogger logger, IOFFDataRepository oFFDataRepository, IOFFCategoryRepository oFFCategoryRepository, IOFFDatasCategoryRepository oFFDatasCategoryRepository, string barcode) : base(claims, dTORequest, logger)
        {
            _barcode = barcode;
            _OFFDataRepository = oFFDataRepository;
            _OFFCategoryRepository = oFFCategoryRepository;
            _OFFDatasCategoryRepository = oFFDatasCategoryRepository;
        }

        protected async override Task<(GetOFFDataDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            if (DTORequest == null)
                return (null, HttpStatusCode.BadRequest, null);

            OpenFoodFactsData openFoodFactsData = await _OFFDataRepository.GetByBarcode(_barcode);

            if (openFoodFactsData != null)
            {
                GetOFFDataDTOResponse dtoResponse = new GetOFFDataDTOResponse(
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

            ProductData productData;
            (openFoodFactsData, productData) = await _OFFDataRepository.InsertFromBarcode(_barcode);

            if (openFoodFactsData != null && productData != null)
            {
                string[] categories = productData.Categories.Split(", ");
                foreach (string category in categories)
                {
                    if (await _OFFCategoryRepository.GetByName(category) == null)
                    {
                        OpenFoodFactsCategory openFoodFactsCategory = new OpenFoodFactsCategory()
                        {
                            Name = category
                        };

                        openFoodFactsCategory = await _OFFCategoryRepository.Insert(openFoodFactsCategory);                     
                        if (openFoodFactsCategory == null)
                            return (null, HttpStatusCode.NoContent, "Cannot insert the new category: " + category);

                        OpenFoodFactsDatasCategory openFoodFactsDatasCategory = new OpenFoodFactsDatasCategory
                        {
                            CategoryId = openFoodFactsCategory.Id,
                            DataId = openFoodFactsData.Id
                        };

                        openFoodFactsDatasCategory = await _OFFDatasCategoryRepository.Insert(openFoodFactsDatasCategory);
                        if (openFoodFactsDatasCategory == null)
                            return (null, HttpStatusCode.NoContent, "Cannot insert the OFF data with the category: " + category);
                    }
                };
            }

            GetOFFDataDTOResponse dtoReponse = new GetOFFDataDTOResponse(
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

            return (dtoReponse, HttpStatusCode.OK, null);
        }
    }
}
