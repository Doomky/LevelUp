using LevelUpClient.RequestBuilders;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace LevelUpClient.RequestHandler
{
    public class ChangePasswordRequestHandler : RequestHandler<ChangePasswordRequest>
    {
        public ChangePasswordRequestHandler(string fullAdress) : base(fullAdress)
        {
        }

        public override void Execute(HttpClient httpClient)
        {
            HttpResponseMessage httpResponse = ExecuteMethod(httpClient).GetAwaiter().GetResult();
        }

        public override ChangePasswordRequest RequestBuilder()
        {
            return new ConsoleChangePasswordRequestBuilder()
                .WithPassword()
                .WithNewPassword()
                .Build();
        }
    }
}
