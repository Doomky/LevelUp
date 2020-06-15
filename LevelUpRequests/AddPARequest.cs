using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class AddPARequest : Request
    {
        public string Name { get; set; }
        public double? CalPerKgPerHour { get; set; }

        public AddPARequest() : base(Method.POST)
        {
        }
    }
}
