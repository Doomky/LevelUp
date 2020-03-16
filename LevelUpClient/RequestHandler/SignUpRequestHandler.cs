using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace LevelUpClient.RequestHandler
{
    public class SignUpRequestHandler : RequestHandler<SignUpRequest>
    {
        public SignUpRequestHandler(string fullAdress) : base(fullAdress)
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
        }

        public override SignUpRequest RequestBuilder()
        {
            return new ConsoleSignUpRequestBuilder()
                    .WithLogin()
                    .WithPassword()
                    .WithFirstname()
                    .WithLastname()
                    .WithEmailAddress()
                    .Build();
        }
    }
}
