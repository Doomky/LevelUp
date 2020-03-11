using IdentityModel.Client;
using LevelUpRequests;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LevelUpAPI.RequestHandlers
{
    public class ChangePasswordRequestHandler : RequestHandler<ChangePasswordRequest>
    {
        public const string HTTP = "http://";
        public const string address = "localhost";
        public const string port = "5000";

        protected override void ExecuteRequest(HttpContext context)
        {

        }
    }
}
