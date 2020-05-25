using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class RemovePAEntryRequest : Request
    {
        public int Id { get; set; }
        public RemovePAEntryRequest() : base(Method.POST)
        {
        }
    }
}
