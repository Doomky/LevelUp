using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace LevelUpAPI.Helpers
{
    public static class ClaimsHelpers
    {
        public static (bool, User) CheckClaimsForUser(Request request, HttpContext context, IUserRepository userRepository)
        {
            if (request == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return (false, null);
            }

            ClaimsPrincipal claims = context.User;

            if (claims == null)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.WriteAsync("no claims").GetAwaiter().GetResult();
                return (false, null);
            }

            User user = userRepository.GetUserByClaims(claims).GetAwaiter().GetResult();

            if (user == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.WriteAsync("no user for this client_id").GetAwaiter().GetResult();
                return (false, null);
            }

            return (true, user);
        }
    }
}
