using LevelUpClient.RequestBuilders;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class PasswordRecoveryRequestHandler : RequestHandler<PasswordRecoveryRequest>
    {
        public PasswordRecoveryRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override void Execute(HttpClient httpClient)
        {
            base.Execute(httpClient);
        }

        public override PasswordRecoveryRequest RequestBuilder()
        {
            return new ConsolePasswordRecoveryRequestBuilder()
                        .WithHash()
                        .WithPassword()
                        .Build();
        }
    }
}
