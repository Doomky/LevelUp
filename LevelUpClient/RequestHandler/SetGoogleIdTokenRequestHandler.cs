using LevelUpClient.RequestBuilders;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class SetGoogleIdTokenRequestHandler : RequestHandler<LinkGoogleAccountRequest>
    {
        public SetGoogleIdTokenRequestHandler(string fullAddress) : base(fullAddress)
        {

        }

        public override LinkGoogleAccountRequest RequestBuilder()
        {
            return new ConsoleSetGoogleIdRequestBuilder()
                .WithGoogleId()
                .Build();
        }
    }
}
