using IdentityModel.Client;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpRequests;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace LevelUpAPI.RequestHandlers
{
    public class LinkGoogleAccountRequestHandler : RequestHandler<LinkGoogleAccountRequest>
    {
        private IUserRepository _userRepository;

        public LinkGoogleAccountRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override void ExecuteRequest(HttpContext context)
        {
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
                DateTime expiration = DateTime.Now;
                user.GoogleAccessExpiration = expiration.AddSeconds(expires_in);
                _userRepository.Update(user);
            }
            else
            {
                context.Response.WriteAsync(response).GetAwaiter().GetResult();
            }
            context.Response.StatusCode = (int)httpResponse.StatusCode;
        }
    }
}
