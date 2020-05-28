using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class UpdatePAEntryRequestHandler : RequestHandler<UpdatePAEntryRequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPhysicalActivitiesRepository _physicalActivitiesRepository;
        private readonly IPhysicalActivitiesEntryRepository _physicalActivitiesEntryRepository;

        public UpdatePAEntryRequestHandler(IUserRepository userRepository, IPhysicalActivitiesRepository physicalActivitiesRepository, IPhysicalActivitiesEntryRepository physicalActivitiesEntryRepository)
        {
            _userRepository = userRepository;
            _physicalActivitiesRepository = physicalActivitiesRepository;
            _physicalActivitiesEntryRepository = physicalActivitiesEntryRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(Request, context, _userRepository);
            if (!isOk || user == null)
                return;

            PhysicalActivityEntry PAEntry = _physicalActivitiesEntryRepository.Get(Request.Id).GetAwaiter().GetResult().FirstOrDefault();
            if (PAEntry == null)
            {
                context.Response.StatusCode = StatusCodes.Status204NoContent;
                return;
            }

            PAEntry.DatetimeStart = Request.NewDateTimeStart;
            PAEntry.DatetimeEnd = Request.NewDateTimeEnd;

            PAEntry = _physicalActivitiesEntryRepository.Update(PAEntry).GetAwaiter().GetResult();
            if (PAEntry == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.WriteAsync("Could not update the given physical activity entry, please check body data sanity");
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status200OK;
            }
        }
    }
}
