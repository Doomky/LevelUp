using LevelUpClient.RequestBuilders;
using LevelUpClient.RequestHandler.Interfaces;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class UpdateQuestRequestHandler : RequestHandler<UpdateQuestDTORequest>
    {
        public UpdateQuestRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override UpdateQuestDTORequest RequestBuilder()
        {
            return new ConsoleUpdateQuestRequestBuilder()
                .WithDatas()
                .Build();
        }
    }
}
