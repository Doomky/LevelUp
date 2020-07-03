using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    [JsonObject()]
    public class UpdateQuestDTORequest : DTORequest
    {
        [JsonProperty("data")]
        public Dictionary<string, string> Data { get; set; }

        public UpdateQuestDTORequest() : base(Method.POST)
        {

        }
    }
}
