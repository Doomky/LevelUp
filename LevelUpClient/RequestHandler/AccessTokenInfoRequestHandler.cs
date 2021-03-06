﻿using LevelUpClient.RequestBuilders;
using LevelUpDTO;

namespace LevelUpClient.RequestHandler
{
    internal class AccessTokenInfoRequestHandler : RequestHandler<AccessTokenInfoDTORequest>
    {
        public AccessTokenInfoRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override AccessTokenInfoDTORequest RequestBuilder()
        {
            return new ConsoleAccessTokenInfoRequestBuilder()
                .Build();
        }
    }
}