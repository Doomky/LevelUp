using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class AddPAEntryRequestHandler : RequestHandler<AddPAEntryRequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPhysicalActivitiesRepository _physicalActivitiesRepository;
        private readonly IPhysicalActivitiesEntryRepository _physicalActivitiesEntryRepository;

        public AddPAEntryRequestHandler(IUserRepository userRepository, IPhysicalActivitiesRepository physicalActivitiesRepository, IPhysicalActivitiesEntryRepository physicalActivitiesEntryRepository)
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

            PhysicalActivity PA = _physicalActivitiesRepository.GetPhysicalActivity(Request.Name);
            if (PA == null)
            {
                context.Response.StatusCode = StatusCodes.Status204NoContent;
                return;
            }

            PhysicalActivityEntry PAEntry = _physicalActivitiesEntryRepository.Insert(new PhysicalActivityEntry()
            {
                UserId = user.Id,
                PhysicalActivitesId = PA.Id,
                DatetimeStart = Request.dateTimeStart,
                DatetimeEnd = Request.dateTimeEnd
            }).GetAwaiter().GetResult();

            if (PAEntry != null)
            {
                string PAEntryJson = JsonSerializer.Serialize(PAEntry);
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.WriteAsync(PAEntryJson).GetAwaiter().GetResult();
            }
            else
                context.Response.StatusCode = StatusCodes.Status204NoContent;
        }
    }
}
