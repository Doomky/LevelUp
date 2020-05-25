using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class UpdatePAEntryRequest : Request
    {
        public int Id { get; set; }
        public string NewName { get; set; }
        public float NewKCalPerHour { get; set; }

        public UpdatePAEntryRequest() : base(Method.POST)
        {
        }
    }
}
