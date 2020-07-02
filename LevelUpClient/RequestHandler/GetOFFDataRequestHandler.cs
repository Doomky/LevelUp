using LevelUpClient.RequestBuilders;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class GetOFFDataRequestHandler : RequestHandler<GetOFFDataDTORequest>
    {
        public GetOFFDataRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override void Execute(HttpClient httpClient)
        {
            FullAddress += "/" + Request.Barcode;
            base.Execute(httpClient);
        }

        public override GetOFFDataDTORequest RequestBuilder()
        {
            return new ConsoleGetOFFDataRequestBuilder()
                .WithBarcode()
                .Build();
        }
    }
}
