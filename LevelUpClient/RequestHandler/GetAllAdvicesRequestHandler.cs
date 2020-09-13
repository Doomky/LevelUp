using LevelUpClient.RequestBuilders;
using LevelUpDTO.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class GetAllAdvicesRequestHandler : RequestHandler<GetAllAdvicesByCategoryDTORequest>
    {
        public GetAllAdvicesRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override GetAllAdvicesByCategoryDTORequest RequestBuilder()
        {
            return new ConsoleGetAllAdvicesRequestBuilder()
                .WithCategoryName()
                .Build();
        }
    }
}
