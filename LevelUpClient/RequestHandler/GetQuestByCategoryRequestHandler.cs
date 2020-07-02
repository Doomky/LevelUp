using LevelUpClient.RequestBuilders;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class GetQuestByCategoryRequestHandler : RequestHandler<GetQuestByCategoryDTORequest>
    {
        public GetQuestByCategoryRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override void Execute(HttpClient httpClient)
        {
            FullAddress += "/" + Request.Category;
            base.Execute(httpClient);
        }

        public override GetQuestByCategoryDTORequest RequestBuilder()
        {
            return new ConsoleGetQuestByCategoryRequestBuilder()
                .WithCategory()
                .Build();
        }
    }
}
