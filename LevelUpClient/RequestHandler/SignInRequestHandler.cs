using IdentityModel.Client;
using LevelUpRequests;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace LevelUpClient.RequestHandler
{
    public class SignInRequestHandler : RequestHandler<SignInRequest>
    {
        public SignInRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override void Execute(HttpClient httpClient)
        {
            HttpResponseMessage httpResponse = ExecuteMethod(httpClient).GetAwaiter().GetResult();
            string tokenAsStr = "";
            if (httpResponse.IsSuccessStatusCode)
            {
                tokenAsStr = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
            Console.WriteLine(
$@"response:
status code: {(int)httpResponse.StatusCode} {httpResponse.StatusCode}
body: {tokenAsStr}");
            JObject tokenAsJson = JObject.Parse(tokenAsStr);
            string accessToken = tokenAsJson.TryGetString("access_token");
            httpClient.SetBearerToken(accessToken);
        }

        public override SignInRequest RequestBuilder()
        {
            return new ConsoleSignInRequestBuilder()
                    .WithLogin()
                    .WithEmailAddress()
                    .WithPassword()
                    .Build();
        }
    }
}
