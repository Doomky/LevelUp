using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
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

        public GetOFFDataRequestHandler(IOFFDataRepository oFFDataRepository, string barcode)
        {
            _barcode = barcode;
            _OFFDataRepository = oFFDataRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            OpenFoodFactsData openFoodFactData = _OFFDataRepository.GetByBarcode(_barcode).GetAwaiter().GetResult();

            if (openFoodFactData != null )
            {
                string openFoodFactDataJson = JsonSerializer.Serialize<OpenFoodFactsData>(openFoodFactData);
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.WriteAsync(openFoodFactDataJson).GetAwaiter().GetResult();
            }
            else
            {
                openFoodFactData = _OFFDataRepository.InsertFromBarcode(_barcode).GetAwaiter().GetResult();

                if (openFoodFactData != null)
                {
                    string openFoodFactDataJson = JsonSerializer.Serialize<OpenFoodFactsData>(openFoodFactData);
                    context.Response.StatusCode = StatusCodes.Status200OK;
                    context.Response.WriteAsync(openFoodFactDataJson).GetAwaiter().GetResult();
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status204NoContent;
                }
            }
        }
    }
}
