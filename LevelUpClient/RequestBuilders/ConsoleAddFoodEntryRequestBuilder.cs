using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleAddFoodEntryRequestBuilder : RequestBuilder<AddFoodEntryRequest>
    {
        public ConsoleAddFoodEntryRequestBuilder WithUserId()
        {
            bool isOk = false;
            while (!isOk)
            {
                Console.Write("User id:");
                if (int.TryParse(Console.ReadLine(), out int userId))
                {
                    Request.UserId = userId;
                    isOk = true;
                }
            }
            return this;
        }

        public ConsoleAddFoodEntryRequestBuilder WithOFFId()
        {
            bool isOk = false;
            while (!isOk)
            {
                Console.Write("OpenFoodFact id:");
                if(int.TryParse(Console.ReadLine(), out int offDataId))
                {
                    Request.OFFDataId = offDataId;
                    isOk = true;
                }
            }
            return this;
        }
    }
}
