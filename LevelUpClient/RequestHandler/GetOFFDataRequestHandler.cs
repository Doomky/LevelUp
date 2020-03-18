using LevelUpClient.RequestBuilders;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class GetOFFDataRequestHandler : RequestHandler<GetOFFDataRequest>
    {
        public GetOFFDataRequestHandler(string fullAdress) : base(fullAdress)
        {
        }

        public override void Execute(HttpClient httpClient)
        {
            FullAdress += "/" + Request.Barcode;
           HttpResponseMessage httpResponse = ExecuteMethod(httpClient).GetAwaiter().GetResult();
        }

        public override GetOFFDataRequest RequestBuilder()
        {
            return new ConsoleGetOFFDataRequestBuilder()
                .WithBarcode()
                .Build();
        }
    }
}
