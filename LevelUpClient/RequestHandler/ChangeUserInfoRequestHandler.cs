using LevelUpClient.RequestBuilders;
using LevelUpClient.RequestHandler.Interfaces;
using LevelUpRequests;
using System;
using System.Net.Http;

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
                .WithNewGoogleId()
                .Build();
        }
    }
}