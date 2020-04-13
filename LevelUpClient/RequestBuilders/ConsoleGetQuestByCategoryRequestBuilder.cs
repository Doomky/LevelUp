using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleGetQuestByCategoryRequestBuilder : RequestBuilder<GetQuestByCategoryRequest>
    {
        public ConsoleGetQuestByCategoryRequestBuilder WithCategory()
        {
            Console.Write("Category: ");
            Request.Category = Console.ReadLine();
            return this;
        }
    }
}
