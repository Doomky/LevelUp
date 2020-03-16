using LevelUpClient.RequestBuilders;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class SetGoogleIdTokenRequestHandler : RequestHandler<SetGoogleIdTokenRequest>
    {
        public SetGoogleIdTokenRequestHandler(string fullAdress) : base(fullAdress)
        {

        }

        public override void Execute(HttpClient httpClient)
        {
            HttpResponseMessage httpResponse = ExecuteMethod(httpClient).GetAwaiter().GetResult();
        }

        public override SetGoogleIdTokenRequest RequestBuilder()
        {
            return new ConsoleSetGoogleIdRequestBuilder()
                .WithGoogleId()
                .Build();
        }
    }
}
