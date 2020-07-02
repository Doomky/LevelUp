using LevelUpClient.RequestBuilders;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class PasswordRecoveryRequestHandler : RequestHandler<PasswordRecoveryDTORequest>
    {
        public PasswordRecoveryRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override void Execute(HttpClient httpClient)
        {
            base.Execute(httpClient);
        }

        public override PasswordRecoveryDTORequest RequestBuilder()
        {
            return new ConsolePasswordRecoveryRequestBuilder()
                        .WithHash()
                        .WithPassword()
                        .Build();
        }
    }
}
