using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleGetOFFDataFromCategoryRequestBuilder : RequestBuilder<GetOFFDataFromCategoryRequest>
    {
        public ConsoleGetOFFDataFromCategoryRequestBuilder WithCategory()
        {
            Console.Write("Category: ");
            Request.Category = Console.ReadLine();
            return this;
        }
    }
}
