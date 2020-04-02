using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class GetOFFDataFromCategoryRequest : Request
    {
        public string Category { get; set; }

        public GetOFFDataFromCategoryRequest() : base(Method.GET)
        {

        }
    }
}
