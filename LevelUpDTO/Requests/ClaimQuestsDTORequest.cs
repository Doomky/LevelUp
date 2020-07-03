using Newtonsoft.Json;
using System;

namespace LevelUpDTO
{
    [JsonObject()]
    public class ClaimQuestsDTORequest : DTORequest
    {
        [JsonProperty("questID")]
        public int QuestId { get; set; }
        public ClaimQuestsDTORequest() : base(Method.POST)
        {
        }
    }
}
