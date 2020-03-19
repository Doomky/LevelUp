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
        private readonly string _userId;
        private readonly string _offDataId;

        private readonly IFoodEntryRepository _FoodEntryRepository;

        public AddFoodEntryRequestHandler(IFoodEntryRepository foodEntryRepository, string userId, string offDataId)
        {
            _FoodEntryRepository = foodEntryRepository;
            _userId = userId;
            _offDataId = offDataId;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            FoodEntry foodEntryData = _FoodEntryRepository.Insert(new FoodEntry()
            {
                UserId = int.Parse(_userId),
                OpenFoodFactsDataId = int.Parse(_offDataId),
                Datetime = DateTime.Now
            }).GetAwaiter().GetResult();

            if (foodEntryData != null)
            {
                string foodEntryJson = JsonSerializer.Serialize<FoodEntry>(foodEntryData);
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
