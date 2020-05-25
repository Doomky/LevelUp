using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class RemoveFoodEntryRequest : Request
    {
        public int Id { get; set; }

        public RemoveFoodEntryRequest() : base(Method.POST)
        {

        }
    }
}
