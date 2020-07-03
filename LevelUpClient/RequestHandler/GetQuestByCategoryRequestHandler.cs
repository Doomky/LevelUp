using LevelUpClient.RequestBuilders;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class GetQuestByCategoryRequestHandler : RequestHandler<GetQuestByCategoryDTORequest, GetQuestByCategoryDTOResponse>
    {
        public GetQuestByCategoryRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override GetQuestByCategoryDTOResponse Execute(HttpClient httpClient)
        {
            FullAddress += "/" + DTORequest.Category;
            return base.Execute(httpClient);
        }

        public override GetQuestByCategoryDTORequest RequestBuilder()
        {
            return new ConsoleGetQuestByCategoryRequestBuilder()
                .WithCategory()
                .Build();
        }
    }
}
