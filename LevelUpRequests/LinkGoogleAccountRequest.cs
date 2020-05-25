using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class LinkGoogleAccountRequest : Request
    {
        public string GoogleAuthCode { get; set; }
        public LinkGoogleAccountRequest() : base(Method.POST)
        {

        }
    }
}
