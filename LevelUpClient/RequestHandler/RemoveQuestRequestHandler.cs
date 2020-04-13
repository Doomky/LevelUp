using LevelUpClient.RequestBuilders;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class RemoveQuestRequestHandler : RequestHandler<RemoveQuestRequest>
    {
        public RemoveQuestRequestHandler(string fullAddress) : base(fullAddress)
        {

        }

        public override RemoveQuestRequest RequestBuilder()
        {
            return new ConsoleRemoveQuestRequestBuilder()
                .WithQuestId()
                .Build();
        }
    }
}
