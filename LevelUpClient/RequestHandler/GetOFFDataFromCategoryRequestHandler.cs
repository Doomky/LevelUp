using LevelUpClient.RequestBuilders;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class GetOFFDataFromCategoryRequestHandler : RequestHandler<GetOFFDataFromCategoryDTORequest, GetOFFDataFromCategoryDTOResponse>
    {
        public GetOFFDataFromCategoryRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override DTOResponse Execute(HttpClient httpClient)
        {
            FullAddress += "/" + DTORequest.Category;
            return base.Execute(httpClient);
        }

        public override GetOFFDataFromCategoryDTORequest RequestBuilder()
        {
            return new ConsoleGetOFFDataFromCategoryRequestBuilder()
                .WithCategory()
                .Build();
        }
    }
}
