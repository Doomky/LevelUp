using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LevelUpAPI.RequestHandlers
{
    public class AddPARequestHandler : RequestHandler<AddPADTORequest, AddPADTOResponse>
    {
        private readonly IPhysicalActivitiesRepository _physicalActivitiesRepository;

        public AddPARequestHandler(ClaimsPrincipal claims, AddPADTORequest dtoRequest, ILogger logger, IPhysicalActivitiesRepository physicalActivitiesRepository) : base(claims, dtoRequest, logger)
        {
            _physicalActivitiesRepository = physicalActivitiesRepository;
        }

        protected async override Task<(AddPADTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            if (string.IsNullOrWhiteSpace(DTORequest.Name) || DTORequest.CalPerKgPerHour == null)
                return (null, HttpStatusCode.NoContent, null);

            PhysicalActivity physicalActivity = await _physicalActivitiesRepository.Insert(new PhysicalActivity()
            {
                Name = DTORequest.Name,
                CalPerKgPerHour = (decimal)DTORequest.CalPerKgPerHour
            });

            if (physicalActivity == null)
                return (null, HttpStatusCode.BadRequest, null);

            AddPADTOResponse dtoResponse = new AddPADTOResponse(
                physicalActivity.Id,
                physicalActivity.Name,
                physicalActivity.CalPerKgPerHour
            );

            return (dtoResponse, HttpStatusCode.OK, null);
        }

    }
}
