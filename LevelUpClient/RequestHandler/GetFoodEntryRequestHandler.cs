using LevelUpClient.RequestBuilders;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class GetFoodEntryRequestHandler : RequestHandler<GetFoodEntriesRequest>
    {
        public GetFoodEntryRequestHandler(string fullAddress) : base(fullAddress)
        {

        }

        public override GetFoodEntriesRequest RequestBuilder()
        {
            return new ConsoleGetFoodEntryRequestBuilder()
                .Build();
        }
    }
}
