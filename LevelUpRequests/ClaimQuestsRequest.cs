using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class ClaimQuestsRequest : Request
    {
        public ClaimQuestsRequest() : base(Method.POST)
        {

        }

        public int QuestId { get; set; }
    }
}
