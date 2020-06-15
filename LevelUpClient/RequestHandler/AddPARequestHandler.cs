using LevelUpClient.RequestBuilders;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class AddPARequestHandler : RequestHandler<AddPARequest>
    {
        public AddPARequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override AddPARequest RequestBuilder()
        {
            return new ConsoleAddPARequestBuilder()
                .WithName()
                .WithCalPerKgPerHour()
                .Build();
        }
    }
}
