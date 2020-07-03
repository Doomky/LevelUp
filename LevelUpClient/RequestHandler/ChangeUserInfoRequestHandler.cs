using LevelUpClient.RequestBuilders;
using LevelUpDTO;
using System;

namespace LevelUpClient.RequestHandler
{
    internal class ChangeUserInfoRequestHandler : RequestHandler<ChangeUserInfoDTORequest, ChangeUserInfoDTOResponse>
    {
        public ChangeUserInfoRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override ChangeUserInfoDTORequest RequestBuilder()
        {
            return new ConsoleChangeUserInfoRequestBuilder()
                .WithNewFirstname()
                .WithNewLastname()
                .WithNewEmail()
                .WithNewWeightKg()
                .Build();
        }
    }
}