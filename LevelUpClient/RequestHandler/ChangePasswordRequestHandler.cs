using LevelUpClient.RequestBuilders;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace LevelUpClient.RequestHandler
{
    public class ChangePasswordRequestHandler : RequestHandler<ChangePasswordDTORequest, ChangePasswordDTOResponse>
    {
        public ChangePasswordRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override ChangePasswordDTORequest RequestBuilder()
        {
            return new ConsoleChangePasswordRequestBuilder()
                .WithPassword()
                .WithNewPassword()
                .Build();
        }
    }
}
