using System;

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
