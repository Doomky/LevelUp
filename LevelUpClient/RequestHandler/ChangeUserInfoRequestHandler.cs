using LevelUpClient.RequestBuilders;
using LevelUpRequests;
using System;

namespace LevelUpClient.RequestHandler
{
    internal class ChangeUserInfoRequestHandler : RequestHandler<ChangeUserInfoRequest>
    {
        public ChangeUserInfoRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override ChangeUserInfoRequest RequestBuilder()
        {
            return new ConsoleChangeUserInfoRequestBuilder()
                .WithNewFirstname()
                .WithNewLastname()
                .WithNewEmail()
                .Build();
        }
    }
}