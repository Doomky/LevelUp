using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleLinkGoogleAccountRequestBuilder : RequestBuilder<LinkGoogleAccountDTORequest>
    {
        public ConsoleLinkGoogleAccountRequestBuilder WithGoogleAuthCode()
        {
            Console.Write("Google Auth Code: ");
            Request.GoogleAuthCode = Console.ReadLine();
            return this;
        }
    }
}
