using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LevelUpRequests
{
    public class SignInRequestHandler : RequestHandler<SignInRequest>
    {
        protected virtual async void ExecuteRequest(HttpContext context)
        {
            context.Response.StatusCode = StatusCodes.Status200OK;
        }
    }
}
