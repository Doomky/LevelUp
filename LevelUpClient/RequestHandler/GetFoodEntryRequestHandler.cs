using LevelUpClient.RequestBuilders;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class GetFoodEntriesRequestHandler : RequestHandler<GetFoodEntriesDTORequest>
    {
        public GetFoodEntriesRequestHandler(string fullAddress) : base(fullAddress)
        {

        }

        public override GetFoodEntriesDTORequest RequestBuilder()
        {
            return new ConsoleGetFoodEntriesRequestBuilder()
                .Build();
        }
    }
}
