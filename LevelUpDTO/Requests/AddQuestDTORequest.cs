using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    [JsonObject()]
    public class AddQuestDTORequest : DTORequest
    {
        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }
        [JsonProperty("typeId")]
        public int TypeId { get; set; }
        [JsonProperty("data")]
        public Dictionary<string, string> Data { get; set; }

        public AddQuestDTORequest() : base(Method.POST)
        {
        }
    }
}
