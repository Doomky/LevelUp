using IdentityModel.Client;
using LevelUpAPI.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using IdentityServer4.Models;
using LevelUpRequests;

namespace LevelUpAPI
{
    public class SignInRequestHandler : RequestHandler<SignInRequest>
    {
        public const string HTTP = "http://";
        public const string address = "localhost";
        public const string port = "5000";
        public const string endpoint = "clientcredentials";

        protected override void ExecuteRequest(HttpContext context)
        {
            if (Request == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }
            using (var dbcontext = new levelupContext())
            {
                var query = from users in dbcontext.Users
                            where users.Login == Request.Login || users.Email == Request.EmailAddress
                            select users;
                if (!query.Any())
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    return;
                }
            }

            string fullAddress = $"{HTTP}{address}:{port}";
            var client = new HttpClient();
            DiscoveryDocumentResponse discoDoc = null;
            discoDoc = client.GetDiscoveryDocumentAsync(fullAddress).GetAwaiter().GetResult();
            TokenResponse tokenResponse = client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = discoDoc.TokenEndpoint,
                ClientId = Request.Login,
                ClientSecret = Request.PasswordHash,
                Scope = "api1"
            }).GetAwaiter().GetResult();

            try
            {
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.WriteAsync(tokenResponse.Json.ToString()).GetAwaiter().GetResult();
            }
            catch (Exception e)
            {
                //context.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }
    }
}
