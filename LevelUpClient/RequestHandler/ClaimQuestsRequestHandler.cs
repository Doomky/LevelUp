using LevelUpClient.RequestBuilders;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class ClaimQuestsRequestHandler : RequestHandler<ClaimQuestsDTORequest, ClaimQuestsDTOResponse>
    {
        public ClaimQuestsRequestHandler(string fullAddress) : base(fullAddress)
        {

        }

        public override ClaimQuestsDTORequest RequestBuilder()
        {
            return new ConsoleClaimQuestsRequestBuilder()
                .WithQuestId()
                .Build();
        }
    }
}
