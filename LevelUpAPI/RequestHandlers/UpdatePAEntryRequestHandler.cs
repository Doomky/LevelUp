using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class UpdatePAEntryRequestHandler : RequestHandler<UpdatePAEntryDTORequest, UpdatePAEntryDTOResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPhysicalActivitiesRepository _physicalActivitiesRepository;
        private readonly IPhysicalActivitiesEntryRepository _physicalActivitiesEntryRepository;

        public UpdatePAEntryRequestHandler(
            IUserRepository userRepository,
            IPhysicalActivitiesRepository physicalActivitiesRepository,
            IPhysicalActivitiesEntryRepository physicalActivitiesEntryRepository,
            ClaimsPrincipal claims,
            UpdatePAEntryDTORequest dTORequest,
            ILogger logger)
            : base(claims, dTORequest, logger)
        {
            _userRepository = userRepository;
            _physicalActivitiesRepository = physicalActivitiesRepository;
            _physicalActivitiesEntryRepository = physicalActivitiesEntryRepository;
        }

        protected override async Task<(UpdatePAEntryDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            (User user, HttpStatusCode statusCode, string err) = CheckClaimsForUser(DTORequest, Claims, _userRepository);
            if (user == null)
                return (null, statusCode, err);

            PhysicalActivityEntry PAEntry = _physicalActivitiesEntryRepository.Get(DTORequest.Id).GetAwaiter().GetResult().FirstOrDefault();
            if (PAEntry == null)
            {
                return (null, HttpStatusCode.NoContent, "No physical activity entry found for this id");
            }

            PAEntry.DatetimeStart = DTORequest.NewDateTimeStart;
            PAEntry.DatetimeEnd = DTORequest.NewDateTimeEnd;

            PAEntry = _physicalActivitiesEntryRepository.Update(PAEntry).GetAwaiter().GetResult();
            if (PAEntry == null)
                return (null, HttpStatusCode.BadRequest, "Could not update the given physical activity entry, please check body data sanity");
            return (new UpdatePAEntryDTOResponse(
                PAEntry.Id,
                PAEntry.UserId,
                PAEntry.PhysicalActivitiesId,
                PAEntry.DatetimeStart,
                PAEntry.DatetimeEnd),
                HttpStatusCode.OK, null);
        }
    }
}
