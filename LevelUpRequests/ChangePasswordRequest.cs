using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class ChangePasswordRequest : Request
    {
        public string PasswordHash { get; set; }
        public string NewPasswordHash { get; set; }

        public ChangePasswordRequest() : base(Method.POST)
        {
        }
    }
}
