using System;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using IdentityModel.Client;
using LevelUpDTO;
using LevelUpAPI.DataAccess.Repositories.Interfaces;

namespace LevelUpAPI.RequestHandlers
{
    public class SignInRequestHandler : RequestHandler<SignInDTORequest>
    {
        public const string HTTP = "http://";
        public const string address = "localhost";
        public const string port = "5000";
        public const string endpoint = "clientcredentials";

        private IUserRepository _userRepository;

        public SignInRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            if (Request == null || string.IsNullOrWhiteSpace(Request.PasswordHash)
                || (string.IsNullOrWhiteSpace(Request.Login) && string.IsNullOrWhiteSpace(Request.EmailAddress)))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }

            if (!_userRepository.CanSignIn(Request).GetAwaiter().GetResult())
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }

            Dbo.User user;
            if (!string.IsNullOrEmpty(Request.EmailAddress))
            {
                user = _userRepository.GetUserByLoginOrEmail(null, Request.EmailAddress).GetAwaiter().GetResult();
                
                if (user != null)
                {
                    Request.Login = user.Login;
                }
            }
            else
                user = _userRepository.GetUserByLoginOrEmail(Request.Login, null).GetAwaiter().GetResult();

            string fullAddress = $"{HTTP}{address}:{port}";
            var client = new HttpClient();
            DiscoveryDocumentResponse discoDoc = client.GetDiscoveryDocumentAsync(fullAddress).GetAwaiter().GetResult();
            ClientCredentialsTokenRequest clientCredentialsTokenRequest = new ClientCredentialsTokenRequest
            {
                Address = discoDoc.TokenEndpoint,
                ClientId = Request.Login,
                ClientSecret = Request.PasswordHash,
                Scope = "api1"
            };
            TokenResponse tokenResponse = client.RequestClientCredentialsTokenAsync(clientCredentialsTokenRequest).GetAwaiter().GetResult();
            
            string jsonAsString = tokenResponse.Json.ToString();

            context.Response.StatusCode = (int)tokenResponse.HttpStatusCode;
            if (context.Response.StatusCode == StatusCodes.Status200OK)
            {
                user.LastLoginDate = DateTime.Now;
                _userRepository.Update(user);
            }
            context.Response.WriteAsync(jsonAsString).GetAwaiter().GetResult();
        }
    }
}
