using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class UpdateFoodEntryRequest : Request
    {
        public int Id { get; set; }
        public int OFFDataId { get; set; }
        public DateTime DateTime { get; set; }

        public UpdateFoodEntryRequest() : base(Method.POST)
        {

        }
    }
}
