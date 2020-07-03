using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    [JsonObject]
    public class RemoveQuestDTORequest : DTORequest
    {
        [JsonProperty("questId")]
        public int QuestId { get; set; }

        public RemoveQuestDTORequest() : base(Method.POST)
        {
        }
    }
}
