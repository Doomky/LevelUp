using LevelUpClient.RequestBuilders;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class RemoveGoogleIdRequestHandler : RequestHandler<RemoveGoogleIdTokenRequest>
    {
        public RemoveGoogleIdRequestHandler(string fullAdress) : base(fullAdress)
        {

        }

        public override void Execute(HttpClient httpClient)
        {
            HttpResponseMessage httpResponse = ExeuteMethod(httpClient).GetAwaiter().GetResult();
        }

        public override RemoveGoogleIdTokenRequest RequestBuilder()
        {
            return new ConsoleRemoveGoogleIdRequestBuilder().Build();
        }
    }
}
