using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleGetQuestByCategoryRequestBuilder : RequestBuilder<GetQuestByCategoryDTORequest>
    {
        public ConsoleGetQuestByCategoryRequestBuilder WithCategory()
        {
            Console.Write("Category: ");
            Request.Category = Console.ReadLine();
            return this;
        }
    }
}
