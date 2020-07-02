using LevelUpClient.RequestBuilders;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class AddFoodEntryRequestHandler : RequestHandler<AddFoodEntryDTORequest>
    {
        public AddFoodEntryRequestHandler(string fullAddress) : base(fullAddress)
        {

        }

        public override AddFoodEntryDTORequest RequestBuilder()
        {
            return new ConsoleAddFoodEntryRequestBuilder()
                .WithOFFId()
                .Build();
        }
    }
}
