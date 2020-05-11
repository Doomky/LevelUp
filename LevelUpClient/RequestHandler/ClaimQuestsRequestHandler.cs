using LevelUpClient.RequestBuilders;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class ClaimQuestsRequestHandler : RequestHandler<ClaimQuestsRequest>
    {
        public ClaimQuestsRequestHandler(string fullAddress) : base(fullAddress)
        {

        }

        public override ClaimQuestsRequest RequestBuilder()
        {
            return new ConsoleClaimQuestsRequestBuilder()
                .WithQuestId()
                .Build();
        }
    }
}
