using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
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
            (User user, HttpStatusCode statusCode, string err) = await CheckClaimsForUser(DTORequest, Claims, _userRepository);
            if (user == null)
                return (null, statusCode, err);

            user.GoogleAccessExpiration = null;
            user.GoogleAccessToken = null;
            user.GoogleRefreshToken = null;
            user = await _userRepository.Update(user);
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
