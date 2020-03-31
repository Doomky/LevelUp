using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class ForgotPasswordRequest : Request
    {
        public ForgotPasswordRequest() : base(Method.POST)
        {

        }

        public string Login { get; set; }
        public string EmailAddress { get; set; }
    }
}
