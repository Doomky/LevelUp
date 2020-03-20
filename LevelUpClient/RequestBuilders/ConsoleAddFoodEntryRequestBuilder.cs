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
                try
                {
                    Request.UserId = int.Parse(Console.ReadLine());
                    isOk = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
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
                try
                {
                    Request.OFFDataId = int.Parse(Console.ReadLine());
                    isOk = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return this;
        }
    }
}
