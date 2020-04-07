using LevelUpClient.RequestBuilders;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class GetQuestByCategoryRequestHandler : RequestHandler<GetQuestByCategoryRequest>
    {
        public GetQuestByCategoryRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override void Execute(HttpClient httpClient)
        {
            FullAddress += "/" + Request.Category;
            base.Execute(httpClient);
        }

        public override GetQuestByCategoryRequest RequestBuilder()
        {
            return new ConsoleGetQuestByCategoryRequestBuilder()
                .WithCategory()
                .Build();
        }
    }
}
