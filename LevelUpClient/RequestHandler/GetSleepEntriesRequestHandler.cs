using LevelUpClient.RequestBuilders;
using LevelUpDTO.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class GetSleepEntriesRequestHandler : RequestHandler<GetSleepEntriesDTORequest>
    {
        public GetSleepEntriesRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override GetSleepEntriesDTORequest RequestBuilder()
        {
            return new ConsoleGetSleepEntriesRequestBuilder()
                .Build();
        }
    }
}
