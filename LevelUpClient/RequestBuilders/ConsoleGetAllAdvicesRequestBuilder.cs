using LevelUpDTO.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleGetAllAdvicesRequestBuilder : RequestBuilder<GetAllAdvicesByCategoryDTORequest>
    {
        public ConsoleGetAllAdvicesRequestBuilder WithCategoryName()
        {
            Console.Write("Category Name: ");
            Request.Category = Console.ReadLine();
            return this;
        }
    }
}
