using LevelUpClient.RequestBuilders;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class UpdateFoodEntryRequestHandler : RequestHandler<UpdateFoodEntryDTORequest, UpdateAvatarDTOResponse>
    {
        public UpdateFoodEntryRequestHandler(string fullAddress) : base(fullAddress)
        {
        }

        public override UpdateFoodEntryDTORequest RequestBuilder()
        {
            return new ConsoleUpdateFoodEntryRequestBuilder()
                        .WithId()
                        .WithOFFDataId()
                        .WithDatetime()
                        .Build();
        }
    }
}
