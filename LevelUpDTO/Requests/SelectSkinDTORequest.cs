using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    [JsonObject()]
    public class SelectSkinDTORequest : DTORequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        public SelectSkinDTORequest() : base(Method.POST)
        {
        }
    }
}
