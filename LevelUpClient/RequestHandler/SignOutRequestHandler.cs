using LevelUpClient.RequestBuilders;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace LevelUpClient.RequestHandler
{
    public class SignOutRequestHandler : RequestHandler<SignOutRequest>
    {
        public SignOutRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override SignOutRequest RequestBuilder()
        {
            return new SignOutRequest();
        }
    }
}
