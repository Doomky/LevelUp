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
    public class AccessTokenInfoRequestHandler : RequestHandler<AccessTokenInfoDTORequest, AccessTokenInfoDTOResponse>
    {
        private IUserRepository _userRepository;

        public AccessTokenInfoRequestHandler(IUserRepository userRepository, ClaimsPrincipal claims, AccessTokenInfoDTORequest dTORequest, ILogger logger) : base(claims, dTORequest, logger)
        {
            _userRepository = userRepository;
        }

        protected async override Task<(AccessTokenInfoDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            (User user, HttpStatusCode statusCode, string err) = await CheckClaimsForUser(DTORequest, Claims, _userRepository);
            if (user == null)
                return (null, statusCode, err);

            AccessTokenInfo accessTokenInfo = new AccessTokenInfo(user);

            return (new AccessTokenInfoDTOResponse(accessTokenInfo.AccessExpiration, accessTokenInfo.AccessToken), HttpStatusCode.OK, null);
        }
    }
}
