using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    [JsonObject()]
    public class RemoveFoodEntryDTORequest : DTORequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        public RemoveFoodEntryDTORequest() : base(Method.POST)
        {

        }
    }
}
