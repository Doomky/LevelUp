using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LevelUpAPI.Helpers
{
    public static class ClaimsHelpers
    {
        public async static Task<(User, HttpStatusCode, string)> CheckClaimsForUser(DTORequest request, ClaimsPrincipal claims, IUserRepository userRepository)
        {
            if (request == null)
                return (null, HttpStatusCode.BadRequest, "no request.");

            if (claims == null)
                return (null, HttpStatusCode.Unauthorized, "no claims.");

            User user = await userRepository.GetUserByClaims(claims);

            if (user == null)
                return (null, HttpStatusCode.BadRequest, "no user for this claims");

            return (user, HttpStatusCode.OK, null);
        }
    }
}
