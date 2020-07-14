using IdentityModel.Client;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class SignOutRequestHandler : RequestHandler<SignOutDTORequest, SignOutDTOResponse>
    {
        public const string HTTP = "http://";
        public const string address = "localhost";
        public const string port = "5000";
        public const string endpoint = "clientcredentials";

        private IUserRepository _userRepository;

        public SignOutRequestHandler(
            IUserRepository userRepository,
            ClaimsPrincipal claims,
            SignOutDTORequest dTORequest,
            ILogger logger)
            : base(claims, dTORequest, logger)
        {
            _userRepository = userRepository;
        }

        protected override async Task<(SignOutDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            (User user, HttpStatusCode statusCode, string err) = await CheckClaimsForUser(DTORequest, Claims, _userRepository);
            if (user == null)
                return (null, statusCode, err);

            string fullAddress = $"{HTTP}{address}:{port}";
            var client = new HttpClient();
            DiscoveryDocumentResponse discoDoc = await client.GetDiscoveryDocumentAsync(fullAddress);
            TokenRevocationRequest tokenRevocationRequest = new TokenRevocationRequest
            {
                Address = discoDoc.RevocationEndpoint,
                ClientId = user.Login,
                ClientSecret = user.PasswordHash,
                Token = DTORequest.AccessToken,
                TokenTypeHint = "access_token"
            };
            TokenRevocationResponse tokenRevocationResponse = await client.RevokeTokenAsync(tokenRevocationRequest);

            return (new SignOutDTOResponse(),
                tokenRevocationResponse.HttpStatusCode,
                tokenRevocationResponse.IsError ? tokenRevocationResponse.Error : null);
        }
    }
}
