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

        public ConsoleAddPAEntryRequestBuilder WithDatetimeStart()
        {
            bool done = false;
            while (!done)
            {
                Console.Write("Datetime start: ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime datetime))
                {
                    Request.dateTimeStart = datetime.ToString();
                    done = true;
                }
            }
            return this;
        }

        public ConsoleAddPAEntryRequestBuilder WithDatetimeEnd()
        {
            bool done = false;
            while (!done)
            {
                Console.Write("Datetime end: ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime datetime))
                {
                    Request.dateTimeEnd = datetime.ToString();
                    done = true;
                }
            }
            return this;
        }
    }
}
