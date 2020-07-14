using IdentityModel.Client;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.DataAccess.GoogleFit;
using LevelUpDTO;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

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

            if (!await _userRepository.CanSignIn(DTORequest))
                return (null, HttpStatusCode.BadRequest, "You are already signed in !");

            Dbo.User user;
            if (!string.IsNullOrEmpty(DTORequest.EmailAddress))
            {
                user = await _userRepository.GetUserByLoginOrEmail(null, DTORequest.EmailAddress);
                
                if (user != null)
                    DTORequest.Login = user.Login;
            }
            else
                user = await _userRepository.GetUserByLoginOrEmail(DTORequest.Login, null);

            string fullAddress = $"{HTTP}{address}:{port}";
            var client = new HttpClient();
            DiscoveryDocumentResponse discoDoc = await client.GetDiscoveryDocumentAsync(fullAddress);
            ClientCredentialsTokenRequest clientCredentialsTokenRequest = new ClientCredentialsTokenRequest
            {
                Address = discoDoc.TokenEndpoint,
                ClientId = DTORequest.Login,
                ClientSecret = DTORequest.PasswordHash,
                Scope = "api1"
            };
            TokenResponse tokenResponse = await client.RequestClientCredentialsTokenAsync(clientCredentialsTokenRequest);
            
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
