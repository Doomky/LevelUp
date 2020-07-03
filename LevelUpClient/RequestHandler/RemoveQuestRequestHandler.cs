using LevelUpClient.RequestBuilders;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class RemoveQuestRequestHandler : RequestHandler<RemoveQuestDTORequest, RemoveQuestDTOResponse>
    {
        public RemoveQuestRequestHandler(string fullAddress) : base(fullAddress)
        {

        }

        public override RemoveQuestDTORequest RequestBuilder()
        {
            return new ConsoleRemoveQuestRequestBuilder()
                .WithQuestId()
                .Build();
        }
    }
}
