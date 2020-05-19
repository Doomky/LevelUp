using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class RemoveFoodEntryRequestHandler : RequestHandler<RemoveFoodEntryRequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly IFoodEntryRepository _foodEntryRepository;

        public RemoveFoodEntryRequestHandler(IUserRepository userRepository, IFoodEntryRepository foodEntryRepository)
        {
            _userRepository = userRepository;
            _foodEntryRepository = foodEntryRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(Request, context, _userRepository);
            if (!isOk || user == null)
                return;

            FoodEntry foodEntry = _foodEntryRepository.GetFoodEntryById(Request.Id);
            if (foodEntry == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.WriteAsync("Could not find the food entry, please check body data sanity");
            }

            if (!_foodEntryRepository.Delete(Request.Id).GetAwaiter().GetResult())
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.WriteAsync("Could not remove the food entry");
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status200OK;
            }
        }
    }
}
