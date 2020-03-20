using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class AddFoodEntryRequest : Request
    {
        public int UserId { get; set; }
        public int OFFDataId { get; set; }

        public AddFoodEntryRequest() : base(Method.POST)
        {

        }
    }
}
