using LevelUpClient.RequestBuilders;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class GetOFFDataRequestHandler : RequestHandler<GetOFFDataDTORequest, GetOFFDataDTOResponse>
    {
        public GetOFFDataRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override DTOResponse Execute(HttpClient httpClient)
        {
            FullAddress += "/" + DTORequest.Barcode;
            return base.Execute(httpClient);
        }

        public override GetOFFDataDTORequest RequestBuilder()
        {
            return new ConsoleGetOFFDataRequestBuilder()
                .WithBarcode()
                .Build();
        }
    }
}
