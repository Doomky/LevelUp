using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class PasswordRecoveryRequest : Request
    {
        public string Hash { get; set; }

        public string PasswordHash { get; set; }

        public PasswordRecoveryRequest() : base(Method.POST)
        {
        }
    }
}
