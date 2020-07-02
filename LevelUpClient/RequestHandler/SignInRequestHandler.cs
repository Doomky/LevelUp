using IdentityModel.Client;
using LevelUpClient.RequestBuilders;
using LevelUpDTO;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace LevelUpClient.RequestHandler
{
    public class SignInRequestHandler : RequestHandler<SignInDTORequest>
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

        public override SignInDTORequest RequestBuilder()
        {
            return new ConsoleSignInRequestBuilder()
                    .WithLoginOrEmailAddress()
                    .WithPassword()
                    .Build();
        }
    }
}
