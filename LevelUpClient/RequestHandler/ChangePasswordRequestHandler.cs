using LevelUpClient.RequestBuilders;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace LevelUpClient.RequestHandler
{
    public class ChangePasswordRequestHandler : RequestHandler<ChangePasswordRequest>
    {
        public ChangePasswordRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override ChangePasswordRequest RequestBuilder()
        {
            return new ConsoleChangePasswordRequestBuilder()
                .WithPassword()
                .WithNewPassword()
                .Build();
        }
    }
}
