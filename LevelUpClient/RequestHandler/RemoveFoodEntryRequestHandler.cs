using LevelUpClient.RequestBuilders;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class RemoveFoodEntryRequestHandler : RequestHandler<RemoveFoodEntryDTORequest>
    {
        public RemoveFoodEntryRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override RemoveFoodEntryDTORequest RequestBuilder()
        {
            return new ConsoleRemoveFoodEntryRequestBuilder()
                .WithId()
                .Build();
        }
    }
}
