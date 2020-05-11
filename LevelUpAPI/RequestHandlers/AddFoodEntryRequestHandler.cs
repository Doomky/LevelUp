using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace LevelUpAPI.RequestHandlers
{
    public class AddFoodEntryRequestHandler : RequestHandler<AddFoodEntryRequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly IFoodEntryRepository _FoodEntryRepository;

        public AddFoodEntryRequestHandler(IUserRepository userRepository, IFoodEntryRepository foodEntryRepository)
        {
            _userRepository = userRepository;
            _FoodEntryRepository = foodEntryRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            if (Request == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }

            ClaimsPrincipal claims = context.User;
            if (claims == null)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.WriteAsync("no claims").GetAwaiter().GetResult();
                return;
            }

            User user = _userRepository.GetUserByClaims(claims).GetAwaiter().GetResult();

            if (user == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.WriteAsync("no user for this client_id").GetAwaiter().GetResult();
                return;
            }

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
