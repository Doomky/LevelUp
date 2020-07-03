using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    [JsonObject()]
    public class AddFoodEntryDTORequest : DTORequest
    {
        [JsonProperty("offDataId")]
        public int OFFDataId { get; set; }

        public AddFoodEntryDTORequest() : base(Method.POST)
        {

        }
    }
}
