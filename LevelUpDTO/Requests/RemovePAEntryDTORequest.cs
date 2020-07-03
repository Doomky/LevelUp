using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    [JsonObject]
    public class RemovePAEntryDTORequest : DTORequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        public RemovePAEntryDTORequest() : base(Method.POST)
        {
        }
    }
}
