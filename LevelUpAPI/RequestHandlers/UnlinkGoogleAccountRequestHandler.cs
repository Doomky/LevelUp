using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LevelUpAPI.RequestHandlers
{
    public class UnlinkGoogleAccountRequestHandler : RequestHandler<UnlinkGoogleAccountRequest>
    {
        private IUserRepository _userRepository;

        public UnlinkGoogleAccountRequestHandler(IUserRepository userRepository)
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

            user.GoogleAccessExpiration = null;
            user.GoogleAccessToken = null;
            user.GoogleRefreshToken = null;
            _userRepository.Update(user);
            context.Response.StatusCode = StatusCodes.Status200OK;
        }
    }
}
