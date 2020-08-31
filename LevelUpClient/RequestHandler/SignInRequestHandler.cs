using IdentityModel.Client;
using LevelUpClient.RequestBuilders;
using LevelUpDTO;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text.Json;

namespace LevelUpClient.RequestHandler
{
    public class SignInRequestHandler : RequestHandler<SignInDTORequest, SignInDTOResponse>
    {
        public SignInRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override DTOResponse Execute(HttpClient httpClient)
        {
            HttpResponseMessage httpResponse = ExecuteMethod(httpClient).GetAwaiter().GetResult();
            string tokenAsStr = httpResponse.IsSuccessStatusCode ? httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult() : "";
            Console.WriteLine(
$@"response:
status code: {(int)httpResponse.StatusCode} {httpResponse.StatusCode}
body: {tokenAsStr}");
            JObject tokenAsJson = JObject.Parse(tokenAsStr);
            string accessToken = tokenAsJson.TryGetString("access_token");
            httpClient.SetBearerToken(accessToken);
            return JsonSerializer.Deserialize<SignInDTOResponse>(tokenAsStr);
        }

        public override SignInDTORequest RequestBuilder()
        {
            return new ConsoleSignInRequestBuilder()
                    .WithLoginOrEmailAddress()
                    .WithPasswordOrPasswordHash()
                    .Build();
        }
    }
}
