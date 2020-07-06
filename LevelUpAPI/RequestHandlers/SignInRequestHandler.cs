using System;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using IdentityModel.Client;
using LevelUpDTO;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.DataAccess.GoogleFit;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Net;

namespace LevelUpAPI.RequestHandlers
{
    public class SignInRequestHandler : RequestHandler<SignInDTORequest, SignInDTOResponse>
    {
        public const string HTTP = "http://";
        public const string address = "localhost";
        public const string port = "5000";
        public const string endpoint = "clientcredentials";

        private IUserRepository _userRepository;

        public SignInRequestHandler(
            IUserRepository userRepository,
            ClaimsPrincipal claims,
            SignInDTORequest dTORequest,
            ILogger logger)
            : base(claims, dTORequest, logger)
        {
            _userRepository = userRepository;
        }

        protected override async Task<(SignInDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            if (DTORequest == null)
                return (null, HttpStatusCode.BadRequest, "Request malformed, please check body data sanity");

            if (!_userRepository.CanSignIn(DTORequest).GetAwaiter().GetResult())
                return (null, HttpStatusCode.BadRequest, "You are already signed in !");

            Dbo.User user;
            if (!string.IsNullOrEmpty(DTORequest.EmailAddress))
            {
                user = _userRepository.GetUserByLoginOrEmail(null, DTORequest.EmailAddress).GetAwaiter().GetResult();
                
                if (user != null)
                    DTORequest.Login = user.Login;
            }
            else
                user = _userRepository.GetUserByLoginOrEmail(DTORequest.Login, null).GetAwaiter().GetResult();

            string fullAddress = $"{HTTP}{address}:{port}";
            var client = new HttpClient();
            DiscoveryDocumentResponse discoDoc = client.GetDiscoveryDocumentAsync(fullAddress).GetAwaiter().GetResult();
            ClientCredentialsTokenRequest clientCredentialsTokenRequest = new ClientCredentialsTokenRequest
            {
                Address = discoDoc.TokenEndpoint,
                ClientId = DTORequest.Login,
                ClientSecret = DTORequest.PasswordHash,
                Scope = "api1"
            };
            TokenResponse tokenResponse = client.RequestClientCredentialsTokenAsync(clientCredentialsTokenRequest).GetAwaiter().GetResult();
            
            string jsonAsString = tokenResponse.Json.ToString();

            if (tokenResponse.HttpStatusCode == HttpStatusCode.OK)
            {
                user.LastLoginDate = DateTime.Now;
                await _userRepository.Update(user);
            }

            return (new SignInDTOResponse(jsonAsString),
                tokenResponse.HttpStatusCode,
                tokenResponse.IsError ? tokenResponse.Error : null);
        }
    }
}
