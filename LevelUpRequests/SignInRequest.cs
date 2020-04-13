using System;

namespace LevelUpRequests
{
    public class SignInRequest : Request
    {
        public string Login { get; set; }
        public string EmailAddress { get; set; }
        public string PasswordHash { get; set; }

        public SignInRequest() : base(Method.POST)
        {
        }
    }
}
