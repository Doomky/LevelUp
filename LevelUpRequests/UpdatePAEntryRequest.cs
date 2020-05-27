using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class UpdatePAEntryRequest : Request
    {
        public int Id { get; set; }
        public DateTime NewDateTimeStart { get; set; }
        public DateTime NewDateTimeEnd { get; set; }

        public UpdatePAEntryRequest() : base(Method.POST)
        {
        }
    }
}
