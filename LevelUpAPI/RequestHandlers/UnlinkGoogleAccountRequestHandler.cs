using System;
using System.Security.Claims;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using LevelUpDTO;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class UnlinkGoogleAccountRequestHandler : RequestHandler<UnlinkGoogleAccountDTORequest, UnlinkGoogleAccountDTOResponse>
    {
        private IUserRepository _userRepository;

        public UnlinkGoogleAccountRequestHandler(
            IUserRepository userRepository,
            ClaimsPrincipal claims,
            UnlinkGoogleAccountDTORequest dTORequest,
            ILogger logger)
            : base(claims, dTORequest, logger)
        {
            _userRepository = userRepository;
        }

        protected override async Task<(UnlinkGoogleAccountDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            (User user, HttpStatusCode statusCode, string err) = CheckClaimsForUser(DTORequest, Claims, _userRepository);
            if (user == null)
                return (null, statusCode, err);

            user.GoogleAccessExpiration = null;
            user.GoogleAccessToken = null;
            user.GoogleRefreshToken = null;
            user = _userRepository.Update(user).GetAwaiter().GetResult();
            if (user != null)
                return (new UnlinkGoogleAccountDTOResponse(
                    user.Login,
                    user.Email,
                    user.GoogleAccessToken,
                    user.GoogleRefreshToken,
                    user.GoogleAccessExpiration),
                    HttpStatusCode.OK, null);
            return (null, HttpStatusCode.BadRequest, "Could not update the given user, please check body data sanity");
        }
    }
}
