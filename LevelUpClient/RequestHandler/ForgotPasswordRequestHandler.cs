using LevelUpClient.RequestBuilders;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class ForgotPasswordRequestHandler : RequestHandler<ForgotPasswordRequest>
    {
        public ForgotPasswordRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override ForgotPasswordRequest RequestBuilder()
        {
            return new ConsoleForgotPasswordRequestBuilder()
                .WithLogin()
                .WithEmailAddress()
                .Build();
        }

        public override void Execute(HttpClient httpClient)
        {
            base.Execute(httpClient);
        }
    }
}
