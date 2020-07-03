using Newtonsoft.Json;
using System;

namespace LevelUpDTO
{
    [JsonObject()]
    public class ChangeUserInfoDTORequest : DTORequest
    {
        [JsonProperty("newFirstname")]
        public string NewFirstname { get; set; }
        [JsonProperty("newLastname")]
        public string NewLastname { get; set; }
        [JsonProperty("newEmail")]
        public string NewEmail { get; set; }
        [JsonProperty("newWeightKg")]
        public byte? NewWeightKg { get; set; }

        public ChangeUserInfoDTORequest() : base(Method.POST)
        {
        }
    }
}
