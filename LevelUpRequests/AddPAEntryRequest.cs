using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class AddPAEntryRequest : Request
    {
        public string Name { get; set; }
        public string dateTimeStart { get; set; }
        public string dateTimeEnd { get; set; }

        public AddPAEntryRequest() : base(Method.POST)
        {
        }
    }
}
