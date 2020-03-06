using LevelUpAPI.Model;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace LevelUpAPI
{
    public class SignInRequestHandler : RequestHandler<SignInRequest>
    {
        protected override async void ExecuteRequest(HttpContext context)
        {
            if (Request == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }

            using (var dbcontext = new levelupContext())
            {
                var query = from users in dbcontext.Users
                            where users.Login == Request.Login || users.Email == Request.EmailAddress
                            select users;
                if (query.Any())
                {
                    context.Response.StatusCode = StatusCodes.Status200OK;
                    return;
                }
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }
        }
    }
}
