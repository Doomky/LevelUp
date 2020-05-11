using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class UpdateQuestRequest : Request
    {
        public Dictionary<string, string> Data { get; set; }

        public UpdateQuestRequest() : base(Method.POST)
        {

        }
    }
}
