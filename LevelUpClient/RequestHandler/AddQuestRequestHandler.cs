using LevelUpClient.RequestBuilders;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class AddQuestRequestHandler : RequestHandler<AddQuestRequest>
    {
        public AddQuestRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override AddQuestRequest RequestBuilder()
        {
            return new ConsoleAddQuestRequestBuilder()
                    .WithCategoryId()
                    .WithTypeId()
                    .WithDatas()
                    .Build();
        }
    }
}
