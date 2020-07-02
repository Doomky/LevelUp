using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleGetOFFDataFromCategoryRequestBuilder : RequestBuilder<GetOFFDataFromCategoryDTORequest>
    {
        public ConsoleGetOFFDataFromCategoryRequestBuilder WithCategory()
        {
            Console.Write("Category: ");
            Request.Category = Console.ReadLine();
            return this;
        }
    }
}
