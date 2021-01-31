using IdentityModel.Client;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Dbo;
using LevelUpDTO;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using static LevelUpAPI.Helpers.ClaimsHelpers;

namespace LevelUpAPI.RequestHandlers
{
    public class LinkGoogleAccountRequestHandler : RequestHandler<LinkGoogleAccountDTORequest>
    {
        private IUserRepository _userRepository;

        public LinkGoogleAccountRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
            (bool isOk, User user) = CheckClaimsForUser(Request, context, _userRepository);
            if (!isOk || user == null)
                return;

            var values = new Dictionary<string, string>
            {
                { "code", Request.GoogleAuthCode },
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
                string accessTokenInfoJson = JsonSerializer.Serialize(accessTokenInfo);

                context.Response.WriteAsync(accessTokenInfoJson).GetAwaiter().GetResult();
                _userRepository.Update(user);
            }
            else
            {
                context.Response.WriteAsync(response).GetAwaiter().GetResult();
            }
        }
    }
}
