using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleGetQuestRequestBuilder : RequestBuilder<GetQuestRequest>
    {
        public ConsoleGetQuestRequestBuilder WithQuestState()
        {
            Console.Write("Quest State: ");
            Request.QuestState = Console.ReadLine();
            return this;
        }
    }
}
