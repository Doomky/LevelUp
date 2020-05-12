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
                if (int.TryParse(Console.ReadLine(), out int Id))
                {
                    Request.Id = Id;
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

        public ConsoleUpdateFoodEntryRequestBuilder WithDatetime()
        {
            bool done = false;
            while (!done)
            {
                Console.Write("Datetime: ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime datetime))
                {
                    Request.DateTime = datetime;
                    done = true;
                }
            }
            return this;
        }
    }
}
