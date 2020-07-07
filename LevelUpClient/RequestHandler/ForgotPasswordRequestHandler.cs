using LevelUpClient.RequestBuilders;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class ForgotPasswordRequestHandler : RequestHandler<ForgotPasswordDTORequest, ForgotPasswordDTOResponse>
    {
        public ForgotPasswordRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override ForgotPasswordDTORequest RequestBuilder()
        {
            return new ConsoleForgotPasswordRequestBuilder()
                .WithLogin()
                .WithEmailAddress()
                .Build();
        }

        public override DTOResponse Execute(HttpClient httpClient)
        {
            return base.Execute(httpClient);
        }
    }
}
