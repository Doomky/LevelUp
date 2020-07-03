using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    [JsonObject()]
    public class UpdateFoodEntryDTORequest : DTORequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("oFFDataId")]
        public int OFFDataId { get; set; }
        [JsonProperty("datetime")]
        public DateTime DateTime { get; set; }

        public UpdateFoodEntryDTORequest() : base(Method.POST)
        {

        }
    }
}
