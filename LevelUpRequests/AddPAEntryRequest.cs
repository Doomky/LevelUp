using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class AddPAEntryRequest : Request
    {
        public string Name { get; set; }
        public float kCalPerHour { get; set; }

        public AddPAEntryRequest() : base(Method.POST)
        {
        }
    }
}
