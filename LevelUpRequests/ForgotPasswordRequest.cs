using System;

namespace LevelUpRequests
{
    public class ForgotPasswordRequest : Request
    {
        public string Login { get; set; }
        public string EmailAddress { get; set; }
        public ForgotPasswordRequest() : base(Method.POST)
        {
        }
    }
}
