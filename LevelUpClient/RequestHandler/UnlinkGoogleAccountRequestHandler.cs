using LevelUpClient.RequestBuilders;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class UnlinkGoogleAccountRequestHandler : RequestHandler<UnlinkGoogleAccountRequest>
    {
        public UnlinkGoogleAccountRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override UnlinkGoogleAccountRequest RequestBuilder()
        {
            return new ConsoleUnlinkGoogleAccountRequestBuilder()
                .Build();
        }
    }
}
