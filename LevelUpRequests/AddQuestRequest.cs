using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class AddQuestRequest : Request
    {
        public int CategoryId { get; set; }
        public int TypeId { get; set; }
        public Dictionary<string, string> Data { get; set; }

        public AddQuestRequest() : base(Method.POST)
        {
        }
    }
}
