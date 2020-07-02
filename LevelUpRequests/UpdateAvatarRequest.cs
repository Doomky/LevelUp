using System;

namespace LevelUpRequests
{
    public class UpdateAvatarRequest : Request
    {
        public int NewSize { get; set; }

        public UpdateAvatarRequest() : base(Method.POST)
        {
        }
    }
}
