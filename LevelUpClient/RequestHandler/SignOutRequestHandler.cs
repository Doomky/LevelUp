using IdentityModel.Client;
using LevelUpClient.RequestBuilders;
using LevelUpDTO;
using System;
using System.Net.Http;

namespace LevelUpClient.RequestHandler
{
    public class SignOutRequestHandler : RequestHandler<SignOutDTORequest, SignOutDTOResponse>
    {
        public SignOutRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override SignOutDTOResponse Execute(HttpClient httpClient)
        {
            HttpResponseMessage httpResponse = ExecuteMethod(httpClient).GetAwaiter().GetResult();
            Console.WriteLine(
$@"response:
status code: {(int)httpResponse.StatusCode} {httpResponse.StatusCode}
body: ");
            httpClient.SetBearerToken(null);
            return new SignOutDTOResponse();
        }

        public override SignOutDTORequest RequestBuilder()
        {
            return new ConsoleSignOutRequestBuilder()
                .WithAccessToken()
                .Build();
        }
    }
}
