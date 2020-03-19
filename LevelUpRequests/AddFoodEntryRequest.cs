using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class AddFoodEntryRequest : Request
    {
        public string UserId { get; set; }
        public string OFFDataId { get; set; }

        public AddFoodEntryRequest() : base(Method.POST)
        {

        }
    }
}
