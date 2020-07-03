using LevelUpClient.RequestBuilders;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class GetPAEntriesRequestHandler : RequestHandler<GetPAEntriesDTORequest, GetPAEntriesDTOResponse>
    {
        public GetPAEntriesRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override GetPAEntriesDTORequest RequestBuilder()
        {
            return new ConsoleGetPAEntriesRequestBuilder()
                .Build();
        }
    }
}
