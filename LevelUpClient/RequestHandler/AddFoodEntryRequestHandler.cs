using LevelUpClient.RequestBuilders;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class AddFoodEntryRequestHandler : RequestHandler<AddFoodEntryRequest>
    {
        public AddFoodEntryRequestHandler(string fullAddress) : base(fullAddress)
        {

        }

        public override AddFoodEntryRequest RequestBuilder()
        {
            return new ConsoleAddFoodEntryRequestBuilder()
                .WithOFFId()
                .Build();
        }
    }
}
