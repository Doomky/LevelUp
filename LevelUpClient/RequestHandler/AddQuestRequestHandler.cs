using LevelUpClient.RequestBuilders;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class AddQuestRequestHandler : RequestHandler<AddQuestDTORequest>
    {
        public AddQuestRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override AddQuestDTORequest RequestBuilder()
        {
            return new ConsoleAddQuestRequestBuilder()
                    .WithCategoryId()
                    .WithTypeId()
                    .WithDatas()
                    .Build();
        }
    }
}
