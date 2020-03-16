using IdentityModel.Client;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace LevelUpClient.RequestHandler
{
    public class SignInRequestHandler : RequestHandler<SignInRequest>
    {
        public SignInRequestHandler(string fullAdress) : base(fullAdress)
        {
        }

        public override void Execute(HttpClient httpClient)
        {
            HttpResponseMessage httpResponse = ExecuteMethod(httpClient).GetAwaiter().GetResult();
            string bodyAsStr = "";
            if (httpResponse.IsSuccessStatusCode)
            {
                bodyAsStr = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
            Console.WriteLine(
$@"response:
status code: {(int)httpResponse.StatusCode} {httpResponse.StatusCode}
body: {bodyAsStr}");
            string accessToken = "";
            httpClient.SetBearerToken(accessToken);
        }

        public override SignInRequest RequestBuilder()
        {
            return new ConsoleSignInRequestBuilder()
                    .WithLogin()
                    .WithPassword()
                    .Build();
        }
    }
}
