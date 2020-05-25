using System;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using IdentityModel.Client;
using LevelUpRequests;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class SignOutRequestHandler : RequestHandler<SignOutRequest>
    {
        public const string HTTP = "http://";
        public const string address = "localhost";
        public const string port = "5000";
        public const string endpoint = "clientcredentials";

        private IUserRepository _userRepository;

        public SignOutRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(Request, context, _userRepository);
            if (!isOk || user == null)
                return;

            string fullAddress = $"{HTTP}{address}:{port}";
            var client = new HttpClient();
            DiscoveryDocumentResponse discoDoc = client.GetDiscoveryDocumentAsync(fullAddress).GetAwaiter().GetResult();
            TokenRevocationRequest tokenRevocationRequest = new TokenRevocationRequest
            {
                Address = discoDoc.RevocationEndpoint,
                ClientId = user.Login,
                ClientSecret = user.PasswordHash,
                Token = Request.AccessToken,
                TokenTypeHint = "access_token"
            };
            TokenRevocationResponse tokenRevocationResponse = client.RevokeTokenAsync(tokenRevocationRequest).GetAwaiter().GetResult();

            context.Response.StatusCode = (int)tokenRevocationResponse.HttpStatusCode;
        }
    }
}
