using LevelUpClient.RequestBuilders;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class UnlinkGoogleAccountRequestHandler : RequestHandler<UnlinkGoogleAccountDTORequest>
    {
        public UnlinkGoogleAccountRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override UnlinkGoogleAccountDTORequest RequestBuilder()
        {
            return new ConsoleUnlinkGoogleAccountRequestBuilder()
                .Build();
        }
    }
}
