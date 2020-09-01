using LevelUpClient.RequestBuilders;
using LevelUpDTO.Requests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class GetAdviceByCategoryRequestHandler : RequestHandler<GetAdviceByCategoryDTORequest>
    {
        public GetAdviceByCategoryRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override void Execute(HttpClient httpClient)
        {
            FullAddress += "/" + Request.Category;
            base.Execute(httpClient);
        }

        public override GetAdviceByCategoryDTORequest RequestBuilder()
        {
            return new ConsoleGetAdviceByCategoryRequestBuilder()
                .WithCategoryName()
                .Build();
        }
    }
}
