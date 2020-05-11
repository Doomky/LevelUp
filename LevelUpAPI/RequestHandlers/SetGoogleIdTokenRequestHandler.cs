using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using LevelUpRequests;
using LevelUpAPI.DataAccess.Repositories.Interfaces;

namespace LevelUpAPI.RequestHandlers
{
    public class SetGoogleIdTokenRequestHandler : RequestHandler<SetGoogleIdTokenRequest>
    {
        private IUserRepository _userRepository;

        public SetGoogleIdTokenRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            if (Request == null || string.IsNullOrWhiteSpace(Request.GoogleIdToken))
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

            user.GoogleId = Request.GoogleIdToken;
            _userRepository.Update(user);
            context.Response.StatusCode = StatusCodes.Status200OK;
        }
    }
}
