using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text.Json;
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
            {
                context.Response.StatusCode = StatusCodes.Status204NoContent;
                return null;
            }

            PhysicalActivity physicalActivity = _physicalActivitiesRepository.Insert(new PhysicalActivity()
            {
                Name = DTORequest.Name,
                CalPerKgPerHour = (decimal)DTORequest.CalPerKgPerHour
            }).GetAwaiter().GetResult();

            if (physicalActivity != null)
            {
                string physicalActivityJson = JsonSerializer.Serialize(physicalActivity);
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.WriteAsync(physicalActivityJson).GetAwaiter().GetResult();
                return JsonSerializer.Deserialize<AddPADTOResponse>(physicalActivityJson);
            }
            else
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
            return null;
        }
    }
}
