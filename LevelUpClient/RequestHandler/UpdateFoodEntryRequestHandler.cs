using LevelUpClient.RequestBuilders;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class UpdateFoodEntryRequestHandler : RequestHandler<UpdateFoodEntryRequest>
    {
        public UpdateFoodEntryRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override UpdateFoodEntryRequest RequestBuilder()
        {
            return new ConsoleUpdateFoodEntryRequestBuilder()
                        .WithId()
                        .WithOFFDataId()
                        .WithDatetime()
                        .Build();
        }
    }
}
