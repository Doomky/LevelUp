using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpAPI.Dbo.OpenFoodFacts;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace LevelUpAPI.RequestHandlers
{
    public class GetOFFDataRequestHandler : RequestHandler<GetOFFDataRequest>
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

        protected override void ExecuteRequest(HttpContext context)
        {
            if (Request == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }

            OpenFoodFactsData openFoodFactsData = _OFFDataRepository.GetByBarcode(_barcode).GetAwaiter().GetResult();

            if (openFoodFactsData != null)
            {
                string openFoodFactsDataJson = JsonSerializer.Serialize(openFoodFactsData);
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.WriteAsync(openFoodFactsDataJson).GetAwaiter().GetResult();
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
                                return;
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
                                return;
                            }
                        }
                    }

                    string openFoodFactsDataJson = JsonSerializer.Serialize(openFoodFactsData);
                    context.Response.StatusCode = StatusCodes.Status200OK;
                    context.Response.WriteAsync(openFoodFactsDataJson).GetAwaiter().GetResult();
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status204NoContent;
                }
            }
        }
    }
}
