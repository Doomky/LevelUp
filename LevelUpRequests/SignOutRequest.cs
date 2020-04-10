using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class SignOutRequest : Request
    {
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string AccessToken { get; set; }

        public SignOutRequest() : base(Method.GET)
        {
        }
    }
}
