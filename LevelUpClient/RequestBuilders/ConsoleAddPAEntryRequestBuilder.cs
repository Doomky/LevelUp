using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleAddPAEntryRequestBuilder : RequestBuilder<AddPAEntryRequest>
    {
        public ConsoleAddPAEntryRequestBuilder WithName()
        {
            Console.Write("Name:");
            Request.Name = Console.ReadLine();
            return this;
        }

        public ConsoleAddPAEntryRequestBuilder WithKCalPerHour()
        {
            bool isOk = false;
            while (!isOk)
            {
                Console.Write("kCal/hour:");
                if (float.TryParse(Console.ReadLine(), out float kCalPerHour))
                {
                    Request.kCalPerHour = kCalPerHour;
                    isOk = true;
                }
            }
            return this;
        }
    }
}
