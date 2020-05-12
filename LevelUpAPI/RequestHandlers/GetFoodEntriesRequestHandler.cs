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
    public class GetFoodEntriesRequestHandler : RequestHandler<GetFoodEntriesRequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly IFoodEntryRepository _foodEntryRepository;

        public GetFoodEntriesRequestHandler(IUserRepository userRepository, IFoodEntryRepository foodEntryRepository)
        {
            _userRepository = userRepository;
            _foodEntryRepository = foodEntryRepository;
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

            List<NbFoodEntriesByLogin> foodEntries = _foodEntryRepository.GetNbFoodEntries(user.Login);

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
