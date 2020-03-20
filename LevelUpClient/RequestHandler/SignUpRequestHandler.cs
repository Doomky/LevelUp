using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace LevelUpClient.RequestHandler
{
    public class SignUpRequestHandler : RequestHandler<SignUpRequest>
    {
        public SignUpRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override SignUpRequest RequestBuilder()
        {
            return new ConsoleSignUpRequestBuilder()
                    .WithLogin()
                    .WithPassword()
                    .WithFirstname()
                    .WithLastname()
                    .WithEmailAddress()
                    .Build();
        }
    }
}
