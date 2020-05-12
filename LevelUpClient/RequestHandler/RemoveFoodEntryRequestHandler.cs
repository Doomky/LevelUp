using LevelUpClient.RequestBuilders;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class RemoveFoodEntryRequestHandler : RequestHandler<RemoveFoodEntryRequest>
    {
        public RemoveFoodEntryRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override RemoveFoodEntryRequest RequestBuilder()
        {
            return new ConsoleRemoveFoodEntryRequestBuilder()
                .WithId()
                .Build();
        }
    }
}
