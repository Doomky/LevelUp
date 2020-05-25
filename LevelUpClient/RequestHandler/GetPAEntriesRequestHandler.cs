using LevelUpClient.RequestBuilders;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class GetPAEntriesRequestHandler : RequestHandler<GetPAEntriesRequest>
    {
        public GetPAEntriesRequestHandler(string fullAddress) : base(fullAddress)
        {

        }

        public override GetPAEntriesRequest RequestBuilder()
        {
            return new ConsoleGetPAEntriesRequestBuilder()
                .Build();
        }
    }
}
