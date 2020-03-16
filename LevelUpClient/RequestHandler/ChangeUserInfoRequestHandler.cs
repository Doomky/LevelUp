using LevelUpClient.RequestBuilders;
using LevelUpClient.RequestHandler.Interfaces;
using LevelUpRequests;
using System.Net.Http;

namespace LevelUpClient.RequestHandler
{
    internal class ChangeUserInfoRequestHandler : RequestHandler<ChangeUserInfoRequest>
    {
        public ChangeUserInfoRequestHandler(string fulladrress) : base(fulladrress)
        {
        }

        public override void Execute(HttpClient httpClient)
        {
            HttpResponseMessage httpResponse = ExecuteMethod(httpClient).GetAwaiter().GetResult();
        }

        public override ChangeUserInfoRequest RequestBuilder()
        {
            return new ConsoleChangeUserInfoRequestBuilder()
                .WithNewFirstname()
                .WithNewLastname()
                .WithNewEmail()
                .WithNewGoogleId()
                .Build();
        }
    }
}