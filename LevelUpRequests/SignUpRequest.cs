using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class SignUpRequest : Request
    {
        public string Login { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string EmailAddress { get; set; }
        public string PasswordHash { get; set; }
    }
}
