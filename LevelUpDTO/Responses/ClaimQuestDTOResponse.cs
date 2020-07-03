using Newtonsoft.Json;
using System;

namespace LevelUpDTO
{
    [JsonObject()]
    public class ClaimQuestDTOResponse : DTOResponse
    {
        [JsonRequired]
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonRequired]
        [JsonProperty("xpGain")]
        public string XpGain { get; set; } 
        [JsonRequired]
        [JsonProperty("message")]
        public string Message { get; set; }
        public ClaimQuestDTOResponse(string state, string xpGain, string message)
        {
            State = state;
            XpGain = xpGain;
            Message = message;
        }
    }
}
