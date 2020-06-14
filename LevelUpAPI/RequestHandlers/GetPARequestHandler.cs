using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace LevelUpAPI.RequestHandlers
{
    public class GetPARequestHandler : RequestHandler<GetPARequest>
    {
        private readonly IPhysicalActivitiesRepository _physicalActivitiesRepository;

        public GetPARequestHandler(IPhysicalActivitiesRepository physicalActivitiesRepository)
        {
            _physicalActivitiesRepository = physicalActivitiesRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            IEnumerable<PhysicalActivity> physicalActivities = _physicalActivitiesRepository.GetAllPhysicalActivities();

            if (physicalActivities != null)
            {
                string physicalActivitiesJson = JsonSerializer.Serialize(physicalActivities);
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.WriteAsync(physicalActivitiesJson).GetAwaiter().GetResult();
            }
            else
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}
