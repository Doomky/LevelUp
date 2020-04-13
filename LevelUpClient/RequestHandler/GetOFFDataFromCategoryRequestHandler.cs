using LevelUpClient.RequestBuilders;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class GetOFFDataFromCategoryRequestHandler : RequestHandler<GetOFFDataFromCategoryRequest>
    {
        public GetOFFDataFromCategoryRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override void Execute(HttpClient httpClient)
        {
            FullAddress += "/" + Request.Category;
            base.Execute(httpClient);
        }

        public override GetOFFDataFromCategoryRequest RequestBuilder()
        {
            return new ConsoleGetOFFDataFromCategoryRequestBuilder()
                .WithCategory()
                .Build();
        }
    }
}
