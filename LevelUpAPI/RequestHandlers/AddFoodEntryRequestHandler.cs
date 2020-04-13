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
    public class AddFoodEntryRequestHandler : RequestHandler<AddFoodEntryRequest>
    {
        private readonly IFoodEntryRepository _FoodEntryRepository;

        public AddFoodEntryRequestHandler(IFoodEntryRepository foodEntryRepository)
        {
            _FoodEntryRepository = foodEntryRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            FoodEntry foodEntryData = _FoodEntryRepository.Insert(new FoodEntry()
            {
                UserId = Request.UserId,
                OpenFoodFactsDataId = Request.OFFDataId,
                Datetime = DateTime.Now
            }).GetAwaiter().GetResult();

            if (foodEntryData != null)
            {
                string foodEntryJson = JsonSerializer.Serialize(foodEntryData);
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.WriteAsync(foodEntryJson).GetAwaiter().GetResult();
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status204NoContent;
            }
        }
    }
}
