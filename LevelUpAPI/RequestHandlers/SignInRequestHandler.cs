using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LevelUpBackend
{
    public class SignInRequestHandler : RequestHandler<SignInRequest>
    {
        protected override async void ExecuteRequest(HttpContext context)
        {
            context.Response.StatusCode = StatusCodes.Status200OK;
        }
    }
}
