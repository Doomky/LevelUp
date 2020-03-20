using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleUpdateFoodEntryRequestBuilder : RequestBuilder<UpdateFoodEntryRequest>
    {
        public ConsoleUpdateFoodEntryRequestBuilder WithId()
        {
            Console.Write("Id: ");
            if (int.TryParse(Console.ReadLine(), out int userId))
                Request.Id = userId;
            return this;
        }

        public ConsoleUpdateFoodEntryRequestBuilder WithUserId()
        {
            Console.Write("User Id: ");
            if (int.TryParse(Console.ReadLine(), out int userId))
                Request.UserId = userId;
            return this;
        }

        public ConsoleUpdateFoodEntryRequestBuilder WithOFFDataId()
        {
            Console.Write("OFF Data Id: ");
            if (int.TryParse(Console.ReadLine(), out int offDataId))
                Request.OFFDataId = offDataId;
            return this;
        }
    }
}
