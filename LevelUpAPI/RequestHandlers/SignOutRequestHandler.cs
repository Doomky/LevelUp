using LevelUpRequests;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.RequestHandlers
{
    public class SignOutRequestHandler : RequestHandler<SignOutRequest>
    {
        protected override Task<HttpContext> CheckBody(HttpContext context)
        {
            return base.CheckBody(context);
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            if (Request == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }
        }
    }
}
