using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class AddPAEntryRequest : Request
    {
        public string Name { get; set; }
        public DateTime dateTimeStart { get; set; }
        public DateTime dateTimeEnd { get; set; }

        public AddPAEntryRequest() : base(Method.POST)
        {
        }
    }
}
