using LevelUpClient.RequestBuilders;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class GetPARequestHandler : RequestHandler<GetPADTORequest>
    {
        public GetPARequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override GetPADTORequest RequestBuilder()
        {
            return new ConsoleGetPARequestBuilder()
                .Build();
        }
    }
}
