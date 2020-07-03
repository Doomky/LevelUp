using LevelUpClient.RequestBuilders;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class AddPARequestHandler : RequestHandler<AddPADTORequest, AddPADTOResponse>
    {
        public AddPARequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override AddPADTORequest RequestBuilder()
        {
            return new ConsoleAddPARequestBuilder()
                .WithName()
                .WithCalPerKgPerHour()
                .Build();
        }
    }
}
