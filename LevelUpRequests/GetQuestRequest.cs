using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class GetQuestRequest : Request
    {
        public GetQuestRequest() : base(Method.GET)
        {
        }
    }
}
