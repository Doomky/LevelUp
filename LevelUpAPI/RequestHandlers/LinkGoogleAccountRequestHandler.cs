using IdentityModel.Client;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class LinkGoogleAccountRequestHandler : RequestHandler<LinkGoogleAccountDTORequest, LinkGoogleAccountDTOResponse>
    {
        private IUserRepository _userRepository;

        public LinkGoogleAccountRequestHandler(ClaimsPrincipal claims, LinkGoogleAccountDTORequest dTORequest, ILogger logger, IUserRepository userRepository) : base(claims, dTORequest, logger)
        {
            _userRepository = userRepository;
        }

        protected override async Task<(LinkGoogleAccountDTOResponse, HttpStatusCode, string)> Handle_Internal()
        {
            (User user, HttpStatusCode statusCode, string errMsg) = CheckClaimsForUser(DTORequest, Claims, _userRepository);
            if (user == null)
                return (null, statusCode, errMsg);

            var values = new Dictionary<string, string>
            {
                { "code", DTORequest.GoogleAuthCode },
                { "client_id", "498756810683-agbruikv9b2j9hjs59rrbpb6j13l0l41.apps.googleusercontent.com" },
                { "client_secret", "9QrjOKzI4ldnqXx_uqcrbOK0" },
                { "access_type", "offline"},
                { "redirect_uri", "http://localhost:3000"},
                { "grant_type", "authorization_code"}
            };
            var httpClient = new HttpClient();            
            var content = new FormUrlEncodedContent(values);
            HttpResponseMessage httpResponse = httpClient.PostAsync("https://oauth2.googleapis.com/token", content).GetAwaiter().GetResult();
            var response = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            if (httpResponse.IsSuccessStatusCode)
            {
                JObject tokenAsJson = JObject.Parse(response);
                user.GoogleAccessToken = tokenAsJson.TryGetString("access_token");
                user.GoogleRefreshToken = tokenAsJson.TryGetString("refresh_token");
                int expires_in = (int)tokenAsJson.TryGetInt("expires_in");
                user.GoogleAccessExpiration = DateTime.Now.AddSeconds(expires_in);
                AccessTokenInfo accessTokenInfo = new AccessTokenInfo(user);
                await _userRepository.Update(user);
                LinkGoogleAccountDTOResponse dTOResponse = new LinkGoogleAccountDTOResponse(accessTokenInfo.AccessToken, accessTokenInfo.AccessExpiration);
                return (dTOResponse, HttpStatusCode.OK, null);
            }
            else
            {
                return (null, HttpStatusCode.BadRequest, "");
            }
        }
    }
}
