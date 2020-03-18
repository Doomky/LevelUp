using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class GetOFFDataRequest : Request
    {
        public string Barcode { get; set; }

        public GetOFFDataRequest() : base(Method.GET)
        {

        }
    }
}
