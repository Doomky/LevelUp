using LevelUpClient.RequestBuilders;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class GetFoodEntriesCountRequestHandler : RequestHandler<GetFoodEntriesCountRequest>
    {
        public GetFoodEntriesCountRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override GetFoodEntriesCountRequest RequestBuilder()
        {
            return new ConsoleGetFoodEntriesCountRequestBuilder()
                .Build();
        }
    }
}
