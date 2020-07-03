using Newtonsoft.Json;
using System;

namespace LevelUpDTO
{
    [JsonObject()]
    public class UpdateAvatarDTORequest : DTORequest
    {
        [JsonProperty("newSize")]
        public int NewSize { get; set; }

        public UpdateAvatarDTORequest() : base(Method.POST)
        {
        }
    }
}
