using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleClaimQuestsRequestBuilder : RequestBuilder<ClaimQuestsDTORequest>
    {
        public ConsoleClaimQuestsRequestBuilder WithQuestId()
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine("QuestId: ");
                if (int.TryParse(Console.ReadLine(), out int questId))
                {
                    Request.questId = questId;
                    done = true;
                }
            }
            return this;
        }
    }
}
