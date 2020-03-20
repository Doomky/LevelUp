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
        public RemoveGoogleIdRequestHandler(string fullAddress) : base(fullAddress)
        {

        }

        public override RemoveGoogleIdTokenRequest RequestBuilder()
        {
            return new ConsoleRemoveGoogleIdRequestBuilder().Build();
        }
    }
}
