using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using LevelUpRequests;
using LevelUpAPI.DataAccess.Repositories.Interfaces;

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
            if (Request == null || string.IsNullOrWhiteSpace(Request.PasswordHash)
                || string.IsNullOrWhiteSpace(Request.NewPasswordHash))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }

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
