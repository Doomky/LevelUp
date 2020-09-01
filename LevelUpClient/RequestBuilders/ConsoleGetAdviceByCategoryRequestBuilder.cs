using LevelUpDTO.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleGetAdviceByCategoryRequestBuilder : RequestBuilder<GetAdviceByCategoryDTORequest>
    {
        public ConsoleGetAdviceByCategoryRequestBuilder WithCategoryName()
        {
            Console.Write("Category Name: ");
            Request.Category = Console.ReadLine();
            return this;
        }
    }
}
