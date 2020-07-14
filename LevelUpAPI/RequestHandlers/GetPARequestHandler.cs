using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using static LevelUpDTO.GetPADTOResponse;

namespace LevelUpAPI.RequestHandlers
{
    public class GetPARequestHandler : RequestHandler<GetPADTORequest, GetPADTOResponse>
    {
        private readonly IPhysicalActivitiesRepository _physicalActivitiesRepository;

        public GetPARequestHandler(ClaimsPrincipal claims, GetPADTORequest dTORequest, ILogger logger, IPhysicalActivitiesRepository physicalActivitiesRepository) : base(claims, dTORequest, logger)
        {
            _physicalActivitiesRepository = physicalActivitiesRepository;
        }

        protected async override Task<(GetPADTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            IEnumerable<PhysicalActivity> physicalActivities = _physicalActivitiesRepository.GetAllPhysicalActivities();

            if (physicalActivities == null)
                return (null, HttpStatusCode.BadRequest, null);

            List<PhysicalActivityDTOResponse> physicalActivitiesDTO = physicalActivities.Select(physicalActivity => new PhysicalActivityDTOResponse(physicalActivity.Id, physicalActivity.Name, physicalActivity.CalPerKgPerHour)).ToList();

            GetPADTOResponse getPADTOResponse = new GetPADTOResponse(physicalActivitiesDTO);

            return (getPADTOResponse, HttpStatusCode.OK, null);
        }
    }
}
