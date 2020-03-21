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
            bool done = false;
            while (!done)
            {
                Console.Write("Id: ");
                if (int.TryParse(Console.ReadLine(), out int userId))
                {
                    Request.Id = userId;
                    done = true;
                }
            }
            return this;
        }

        public ConsoleUpdateFoodEntryRequestBuilder WithUserId()
        {
            bool done = false;
            while (!done)
            {
                Console.Write("User Id: ");
                if (int.TryParse(Console.ReadLine(), out int userId))
                {
                    Request.UserId = userId;
                    done = true;
                }
            }
            return this;
        }

        public ConsoleUpdateFoodEntryRequestBuilder WithOFFDataId()
        {
            bool done = false;
            while (!done)
            {
                Console.Write("OFF Data Id: ");
                if (int.TryParse(Console.ReadLine(), out int offDataId))
                {
                    Request.OFFDataId = offDataId;
                    done = true;
                }
            }
            return this;
        }
    }
}
