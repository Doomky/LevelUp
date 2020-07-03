using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace LevelUpAPI.RequestHandlers
{
    public class GetPARequestHandler : RequestHandler<GetPADTORequest, GetPADTOResponse>
    {
        private readonly IPhysicalActivitiesRepository _physicalActivitiesRepository;

        public GetPARequestHandler(IPhysicalActivitiesRepository physicalActivitiesRepository)
        {
            _physicalActivitiesRepository = physicalActivitiesRepository;
        }

        protected override async Task<GetPADTOResponse> ExecuteRequest(HttpContext context)
        {
            IEnumerable<PhysicalActivity> physicalActivities = _physicalActivitiesRepository.GetAllPhysicalActivities();

            if (physicalActivities != null)
            {
                string physicalActivitiesJson = JsonSerializer.Serialize(physicalActivities);
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.WriteAsync(physicalActivitiesJson).GetAwaiter().GetResult();
                return JsonSerializer.Deserialize<GetPADTOResponse>(physicalActivitiesJson);
            }
            else
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
            return null;
        }
    }
}
