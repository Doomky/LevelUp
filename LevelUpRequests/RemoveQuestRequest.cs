using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class RemoveQuestRequest : Request
    {
        public int QuestId { get; set; }

        public RemoveQuestRequest() : base(Method.POST)
        {
        }
    }
}
