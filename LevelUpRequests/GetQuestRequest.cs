using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class GetQuestRequest : Request
    {
        public string QuestState { get; set; }
        public GetQuestRequest() : base(Method.GET)
        {
        }
    }
}
