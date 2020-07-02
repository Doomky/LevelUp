using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleUpdatePAEntryRequestBuilder : RequestBuilder<UpdatePAEntryDTORequest>
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

        public ConsoleUpdatePAEntryRequestBuilder WithNewDatetimeStart()
        {
            bool done = false;
            while (!done)
            {
                Console.Write("New Datetime start: ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime datetime))
                {
                    Request.NewDateTimeStart = datetime;
                    done = true;
                }
            }
            return this;
        }

        public ConsoleUpdatePAEntryRequestBuilder WithNewDatetimeEnd()
        {
            bool done = false;
            while (!done)
            {
                Console.Write("New Datetime end: ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime datetime))
                {
                    Request.NewDateTimeEnd = datetime;
                    done = true;
                }
            }
            return this;
        }
    }
}
