using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class GetAvatarInfoRequest : Request
    {
        public GetAvatarInfoRequest() : base(Method.GET)
        {
        }
    }
}
