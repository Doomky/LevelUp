using LevelUpClient.RequestBuilders;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class AddPAEntryRequestHandler : RequestHandler<AddPAEntryDTORequest>
    {
        public AddPAEntryRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override AddPAEntryDTORequest RequestBuilder()
        {
            return new ConsoleAddPAEntryRequestBuilder()
                .WithName()
                .WithDatetimeStart()
                .WithDatetimeEnd()
                .Build();
        }
    }
}
