using IdentityModel.Client;
using LevelUpClient.RequestBuilders;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace LevelUpClient.RequestHandler
{
    public class UserInfoRequestHandler : RequestHandler<LevelUpRequests.UserInfoRequest>
    {
        public UserInfoRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override LevelUpRequests.UserInfoRequest RequestBuilder()
        {
            return new ConsoleUserInfoRequestBuilder()
                .Build();
        }
    }
}
