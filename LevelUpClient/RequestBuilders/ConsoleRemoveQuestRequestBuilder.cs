using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleRemoveQuestRequestBuilder : RequestBuilder<RemoveQuestDTORequest>
    {
        public ConsoleRemoveQuestRequestBuilder WithQuestId()
        {
            bool done = false;
            while (!done)
            {
                Console.Write("Quest Id: ");
                if (int.TryParse(Console.ReadLine(), out int questId))
                {
                    Request.QuestId = questId;
                    done = true;
                }
            }
            return this;
        }
    }
}
