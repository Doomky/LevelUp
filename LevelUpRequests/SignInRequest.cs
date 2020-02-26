using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class SignInRequest : Request
    {
        public string Login { get; set; }
        public string EmailAddress { get; set; }

        public string HashPassword { get; set; }
    }
}
