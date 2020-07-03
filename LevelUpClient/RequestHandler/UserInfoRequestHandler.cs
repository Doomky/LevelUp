using LevelUpClient.RequestBuilders;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace LevelUpClient.RequestHandler
{
    public class UserInfoRequestHandler : RequestHandler<UserInfoDTORequest, UserInfoDTOResponse>
    {
        public UserInfoRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override UserInfoDTORequest RequestBuilder()
        {
            return new ConsoleUserInfoRequestBuilder()
                .Build();
        }
    }
}
