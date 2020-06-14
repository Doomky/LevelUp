using LevelUpClient.RequestBuilders;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class GetPARequestHandler : RequestHandler<GetPARequest>
    {
        public GetPARequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override GetPARequest RequestBuilder()
        {
            return new ConsoleGetPARequestBuilder()
                .Build();
        }
    }
}
