using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpAPI.Dbo.OpenFoodFacts;
using LevelUpDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace LevelUpAPI.RequestHandlers
{
    public class GetOFFDataRequestHandler : RequestHandler<GetOFFDataDTORequest, GetOFFDataDTOResponse>
    {
        private readonly string _barcode;
        private readonly IOFFDataRepository _OFFDataRepository;
        private readonly IOFFCategoryRepository _OFFCategoryRepository;
        private readonly IOFFDatasCategoryRepository _OFFDatasCategoryRepository;

        public GetOFFDataRequestHandler(IOFFDataRepository oFFDataRepository, IOFFCategoryRepository oFFCategoryRepository, IOFFDatasCategoryRepository oFFDatasCategoryRepository, string barcode)
        {
            _barcode = barcode;
            _OFFDataRepository = oFFDataRepository;
            _OFFCategoryRepository = oFFCategoryRepository;
            _OFFDatasCategoryRepository = oFFDatasCategoryRepository;
        }

        protected override async Task<GetOFFDataDTOResponse> ExecuteRequest(HttpContext context)
        {
            if (DTORequest == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return null;
            }

            OpenFoodFactsData openFoodFactsData = _OFFDataRepository.GetByBarcode(_barcode).GetAwaiter().GetResult();

            if (openFoodFactsData != null)
            {
                string openFoodFactsDataJson = JsonSerializer.Serialize(openFoodFactsData);
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.WriteAsync(openFoodFactsDataJson).GetAwaiter().GetResult();
                return JsonSerializer.Deserialize<GetOFFDataDTOResponse>(openFoodFactsDataJson);
            }
            else
            {
                ProductData productData;
                (openFoodFactsData, productData) = _OFFDataRepository.InsertFromBarcode(_barcode).GetAwaiter().GetResult();

                if (openFoodFactsData != null && productData != null)
                {
                    string[] categories = productData.Categories.Split(", ");
                    foreach (string category in categories)
                    {
                        if (_OFFCategoryRepository.GetByName(category).GetAwaiter().GetResult() == null)
                        {
                            OpenFoodFactsCategory openFoodFactsCategory = new OpenFoodFactsCategory
                            {
                                Name = category
                            };
                            openFoodFactsCategory = _OFFCategoryRepository.Insert(openFoodFactsCategory).GetAwaiter().GetResult();
                            if (openFoodFactsCategory == null)
                            {
                                context.Response.StatusCode = StatusCodes.Status204NoContent;
                                return null;
                            }

                            OpenFoodFactsDatasCategory openFoodFactsDatasCategory = new OpenFoodFactsDatasCategory
                            {
                                CategoryId = openFoodFactsCategory.Id,
                                DataId = openFoodFactsData.Id
                            };
                            openFoodFactsDatasCategory = _OFFDatasCategoryRepository.Insert(openFoodFactsDatasCategory).GetAwaiter().GetResult();
                            if (openFoodFactsDatasCategory == null)
                            {
                                context.Response.StatusCode = StatusCodes.Status204NoContent;
                                return null;
                            }
                        }
                    }

                    string openFoodFactsDataJson = JsonSerializer.Serialize(openFoodFactsData);
                    context.Response.StatusCode = StatusCodes.Status200OK;
                    context.Response.WriteAsync(openFoodFactsDataJson).GetAwaiter().GetResult();
                    return JsonSerializer.Deserialize<GetOFFDataDTOResponse>(openFoodFactsDataJson);
                }
                else
                    context.Response.StatusCode = StatusCodes.Status204NoContent;
                return null;
            }
        }
    }
}
