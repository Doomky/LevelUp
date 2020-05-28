using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text.Json;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class GetTotalPAEntriesRequestHandler : RequestHandler<GetPAEntriesRequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPhysicalActivitiesEntryRepository _physicalActivitiesEntryRepository;

        public GetTotalPAEntriesRequestHandler(IUserRepository userRepository, IPhysicalActivitiesEntryRepository physicalActivitiesEntryRepository)
        {
            _userRepository = userRepository;
            _physicalActivitiesEntryRepository = physicalActivitiesEntryRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(Request, context, _userRepository);
            if (!isOk || user == null)
                return;

            IEnumerable<NbPhysicalActivityEntryByLogin> totalPAEntries =  _physicalActivitiesEntryRepository.GetTotalByLogin(user.Login).GetAwaiter().GetResult();

            if (totalPAEntries != null)
            {
                string PAEntriesJson = JsonSerializer.Serialize(totalPAEntries);
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.WriteAsync(PAEntriesJson).GetAwaiter().GetResult();
            }
            else
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}
