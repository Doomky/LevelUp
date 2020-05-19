using IdentityModel.Client;
using LevelUpClient.RequestBuilders;
using LevelUpRequests;
using System;
using System.Net.Http;

namespace LevelUpClient.RequestHandler
{
    public class SignOutRequestHandler : RequestHandler<SignOutRequest>
    {
        public SignOutRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override void Execute(HttpClient httpClient)
        {
            HttpResponseMessage httpResponse = ExecuteMethod(httpClient).GetAwaiter().GetResult();
            Console.WriteLine(
$@"response:
status code: {(int)httpResponse.StatusCode} {httpResponse.StatusCode}
body: ");
            httpClient.SetBearerToken(null);
        }

        public override SignOutRequest RequestBuilder()
        {
            return new ConsoleSignOutRequestBuilder()
                .WithAccessToken()
                .Build();
        }
    }
}
