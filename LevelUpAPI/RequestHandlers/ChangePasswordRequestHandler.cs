using IdentityModel.Client;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpRequests;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace LevelUpAPI.RequestHandlers
{
    public class ChangePasswordRequestHandler : RequestHandler<ChangePasswordRequest>
    {
        public const string HTTP = "http://";
        public const string address = "localhost";
        public const string port = "5000";

        private readonly IUserRepository _userRepository;

        public ChangePasswordRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            ClaimsPrincipal claims = context.User;
            if (claims == null)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.WriteAsync("no claims").GetAwaiter().GetResult();
                return;
            }

            Dbo.User user = _userRepository.GetUserByClaims(claims).GetAwaiter().GetResult();

            if (user == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.WriteAsync("no user for this client_id").GetAwaiter().GetResult();
                return;
            }

            if (user.PasswordHash != Request.PasswordHash)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.WriteAsync("wrong password").GetAwaiter().GetResult();
                return;
            }

            user.PasswordHash = Request.NewPasswordHash;
            _userRepository.Update(user).GetAwaiter().GetResult();

            context.Response.StatusCode = StatusCodes.Status200OK;
        }
    }
}
