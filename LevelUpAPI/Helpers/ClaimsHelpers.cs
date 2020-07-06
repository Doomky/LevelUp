using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Security.Claims;

namespace LevelUpAPI.Helpers
{
    public static class ClaimsHelpers
    {
        public static (User, HttpStatusCode, string) CheckClaimsForUser(DTORequest request, ClaimsPrincipal claims, IUserRepository userRepository)
        {
            if (request == null)
                return (null, HttpStatusCode.BadRequest, "no request.");

            if (claims == null)
                return (null, HttpStatusCode.Unauthorized, "no claims.");

            User user = userRepository.GetUserByClaims(claims).GetAwaiter().GetResult();

            if (user == null)
                return (null, HttpStatusCode.BadRequest, "no user for this claims");

            return (user, HttpStatusCode.OK, null);
        }
    }
}
