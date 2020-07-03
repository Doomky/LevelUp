using LevelUpClient.RequestBuilders;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class GetFoodEntriesCountRequestHandler : RequestHandler<GetFoodEntriesCountDTORequest, GetFoodEntriesCountDTOResponse>
    {
        public GetFoodEntriesCountRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override GetFoodEntriesCountDTORequest RequestBuilder()
        {
            return new ConsoleGetFoodEntriesCountRequestBuilder()
                .Build();
        }
    }
}
