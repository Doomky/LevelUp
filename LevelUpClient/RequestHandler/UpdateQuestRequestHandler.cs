using LevelUpClient.RequestBuilders;
using LevelUpClient.RequestHandler.Interfaces;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class UpdateQuestRequestHandler : RequestHandler<UpdateQuestRequest>
    {
        public UpdateQuestRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override UpdateQuestRequest RequestBuilder()
        {
            return new ConsoleUpdateQuestRequestBuilder()
                .WithDatas()
                .Build();
        }
    }
}
