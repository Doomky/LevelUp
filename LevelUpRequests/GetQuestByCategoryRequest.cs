using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class GetQuestByCategoryRequest : Request
    {
        public string Category { get; set; }

        public GetQuestByCategoryRequest() : base(Method.GET)
        {
        }
    }
}
