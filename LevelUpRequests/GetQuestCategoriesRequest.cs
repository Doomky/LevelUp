using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class GetQuestCategoriesRequest : Request
    {
        public GetQuestCategoriesRequest() : base(Method.GET)
        {
        }
    }
}
