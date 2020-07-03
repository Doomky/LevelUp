using LevelUpClient.RequestBuilders;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class LinkGoogleAccountRequestHandler : RequestHandler<LinkGoogleAccountDTORequest, LinkGoogleAccountDTOResponse>
    {
        public LinkGoogleAccountRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override LinkGoogleAccountDTORequest RequestBuilder()
        {
            return new ConsoleLinkGoogleAccountRequestBuilder()
                .WithGoogleAuthCode()
                .Build();
        }
    }
}
