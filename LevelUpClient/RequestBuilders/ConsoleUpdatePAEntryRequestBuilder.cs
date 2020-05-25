using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleUpdatePAEntryRequestBuilder : RequestBuilder<UpdatePAEntryRequest>
    {
        public ConsoleUpdatePAEntryRequestBuilder WithId()
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

        public ConsoleUpdatePAEntryRequestBuilder WithNewName()
        {
            Console.Write("New name: ");
            Request.NewName = Console.ReadLine();
            return this;
        }

        public ConsoleUpdatePAEntryRequestBuilder WithNewKCalPerHour()
        {
            bool done = false;
            while (!done)
            {
                Console.Write("New KCalPerHour: ");
                if (float.TryParse(Console.ReadLine(), out float NewKCalPerHour))
                {
                    Request.NewKCalPerHour = NewKCalPerHour;
                    done = true;
                }
            }
            return this;
        }
    }
}
