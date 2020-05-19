using LevelUpClient.RequestBuilders;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class AddPAEntryRequestHandler : RequestHandler<AddPAEntryRequest>
    {
        public AddPAEntryRequestHandler(string fullAddress) : base(fullAddress)
        {

        }

        public override AddPAEntryRequest RequestBuilder()
        {
            return new ConsoleAddPAEntryRequestBuilder()
                .WithName()
                .WithKCalPerHour()
                .Build();
        }
    }
}
