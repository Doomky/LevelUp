using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class GetFoodEntriesCountRequestHandler : RequestHandler<GetFoodEntriesCountRequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly IFoodEntryRepository _foodEntryRepository;

        public GetFoodEntriesCountRequestHandler(IUserRepository userRepository, IFoodEntryRepository foodEntryRepository)
        {
            _userRepository = userRepository;
            _foodEntryRepository = foodEntryRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(Request, context, _userRepository);
            if (!isOk || user == null)
                return;

            List<NbFoodEntryByLogin> foodEntries = _foodEntryRepository.GetNbFoodEntries(user.Login);

            if (foodEntries != null)
            {
                string foodEntriesJson = JsonSerializer.Serialize(foodEntries);
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.WriteAsync(foodEntriesJson).GetAwaiter().GetResult();
            }
            else
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}
