using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class GetFoodEntriesRequest : Request
    {
        public GetFoodEntriesRequest() : base(Method.GET)
        {
        }
    }
}
