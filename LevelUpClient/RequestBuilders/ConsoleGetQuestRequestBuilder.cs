using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleGetQuestRequestBuilder : RequestBuilder<GetQuestDTORequest>
    {
        public ConsoleGetQuestRequestBuilder WithQuestState()
        {
            Console.Write("Quest State: ");
            Request.QuestState = Console.ReadLine();
            return this;
        }
    }
}
