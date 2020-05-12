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
    public class GetPAEntriesRequestHandler : RequestHandler<GetPAEntriesRequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPhysicalActivitiesEntryRepository _physicalActivitiesEntryRepository;

        public GetPAEntriesRequestHandler(IUserRepository userRepository, IPhysicalActivitiesEntryRepository physicalActivitiesEntryRepository)
        {
            _userRepository = userRepository;
            _physicalActivitiesEntryRepository = physicalActivitiesEntryRepository;
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

            List<NbPhysicalActivitiesEntriesByLogin> PAEntries = _physicalActivitiesEntryRepository.GetNbPhysicalActivitiesEntries(user.Login);

            if (PAEntries != null)
            {
                string PAEntriesJson = JsonSerializer.Serialize(PAEntries);
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.WriteAsync(PAEntriesJson).GetAwaiter().GetResult();
            }
            else
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}
