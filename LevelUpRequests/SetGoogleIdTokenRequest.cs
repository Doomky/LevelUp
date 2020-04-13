using System;

namespace LevelUpRequests
{
    public class SetGoogleIdTokenRequest : Request
    {
        public string GoogleIdToken { get; set; }
        public SetGoogleIdTokenRequest() : base(Method.POST)
        {
        }
    }
}
