using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleClaimQuestsRequestBuilder : RequestBuilder<ClaimQuestsRequest>
    {
        public ConsoleClaimQuestsRequestBuilder WithQuestId()
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine("QuestId: ");
                if (int.TryParse(Console.ReadLine(), out int userId))
                {
                    Request.QuestId = userId;
                    done = true;
                }
            }
            return this;
        }
    }
}
