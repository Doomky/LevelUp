using LevelUpClient.RequestBuilders;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class GetFoodEntriesRequestHandler : RequestHandler<GetFoodEntriesRequest>
    {
        public GetFoodEntriesRequestHandler(string fullAddress) : base(fullAddress)
        {

        }

        public override GetFoodEntriesRequest RequestBuilder()
        {
            return new ConsoleGetFoodEntriesRequestBuilder()
                .Build();
        }
    }
}
