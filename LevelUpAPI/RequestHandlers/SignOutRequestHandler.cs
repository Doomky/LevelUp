using System;
using System.Net.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using IdentityModel.Client;
using LevelUpRequests;
using LevelUpAPI.DataAccess.Repositories.Interfaces;

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
            if (Request == null || string.IsNullOrWhiteSpace(Request.Login)
                || string.IsNullOrWhiteSpace(Request.PasswordHash)
                || string.IsNullOrWhiteSpace(Request.AccessToken))
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

            string fullAddress = $"{HTTP}{address}:{port}";
            var client = new HttpClient();
            DiscoveryDocumentResponse discoDoc = client.GetDiscoveryDocumentAsync(fullAddress).GetAwaiter().GetResult();
            TokenRevocationRequest tokenRevocationRequest = new TokenRevocationRequest
            {
                Address = discoDoc.RevocationEndpoint,
                ClientId = Request.Login,
                ClientSecret = Request.PasswordHash,
                Token = Request.AccessToken
            };
            TokenRevocationResponse tokenRevocationResponse = client.RevokeTokenAsync(tokenRevocationRequest).GetAwaiter().GetResult();

            string jsonAsString = tokenRevocationResponse.Json.ToString();

            context.Response.StatusCode = (int)tokenRevocationResponse.HttpStatusCode;
            context.Response.WriteAsync(jsonAsString).GetAwaiter().GetResult();
        }
    }
}
