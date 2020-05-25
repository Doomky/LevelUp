using LevelUpClient.RequestBuilders;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class LinkGoogleAccountRequestHandler : RequestHandler<LinkGoogleAccountRequest>
    {
        public LinkGoogleAccountRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override LinkGoogleAccountRequest RequestBuilder()
        {
            return new ConsoleLinkGoogleAccountRequestBuilder()
                .WithGoogleAuthCode()
                .Build();
        }
    }
}
