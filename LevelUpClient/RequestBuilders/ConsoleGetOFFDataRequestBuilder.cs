using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleGetOFFDataRequestBuilder : RequestBuilder<GetOFFDataDTORequest>
    {
        public ConsoleGetOFFDataRequestBuilder WithBarcode()
        {
            Console.Write("Barcode :");
            Request.Barcode = Console.ReadLine();
            return this;
        }
    }
}
