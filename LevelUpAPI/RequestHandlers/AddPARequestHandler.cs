using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace LevelUpAPI.RequestHandlers
{
    public class AddPARequestHandler : RequestHandler<AddPARequest>
    {
        private readonly IPhysicalActivitiesRepository _physicalActivitiesRepository;

        public AddPARequestHandler(IPhysicalActivitiesRepository physicalActivitiesRepository)
        {
            _physicalActivitiesRepository = physicalActivitiesRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            if (string.IsNullOrWhiteSpace(Request.Name) || Request.CalPerKgPerHour == null)
                context.Response.StatusCode = StatusCodes.Status204NoContent;

            PhysicalActivity physicalActivity = _physicalActivitiesRepository.Insert(new PhysicalActivity()
            {
                Name = Request.Name,
                CalPerKgPerHour = (decimal)Request.CalPerKgPerHour
            }).GetAwaiter().GetResult();

            if (physicalActivity != null)
            {
                string physicalActivityJson = JsonSerializer.Serialize(physicalActivity);
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.WriteAsync(physicalActivityJson).GetAwaiter().GetResult();
            }
            else
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}
