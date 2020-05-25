using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleRemovePAEntryRequestBuilder : RequestBuilder<RemovePAEntryRequest>
    {
        public ConsoleRemovePAEntryRequestBuilder WithId()
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
    }
}
