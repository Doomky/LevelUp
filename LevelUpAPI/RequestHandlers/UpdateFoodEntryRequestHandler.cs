using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.RequestHandlers
{
    public class UpdateFoodEntryRequestHandler : RequestHandler<UpdateFoodEntryRequest>
    {
        private readonly IFoodEntryRepository _foodEntryRepository;

        protected override void ExecuteRequest(HttpContext context)
        {
            Dbo.FoodEntry foodEntry = new Dbo.FoodEntry()
            {
                Id = Request.Id,
                Datetime = Request.DateTime,
                OpenFoodFactsDataId = Request.OFFDataId,
                UserId = Request.UserId
            };

            foodEntry = _foodEntryRepository.Update(foodEntry).GetAwaiter().GetResult();
            if (foodEntry == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.WriteAsync("Could not update the given food entry, please check body data sanity");
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status200OK;
            }
        }
    }
}
