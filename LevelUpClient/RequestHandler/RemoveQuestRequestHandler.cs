using LevelUpClient.RequestBuilders;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class RemoveQuestRequestHandler : RequestHandler<RemoveQuestDTORequest>
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
