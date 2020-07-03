using Newtonsoft.Json;
using System;

namespace LevelUpDTO
{
    [JsonObject()]
    public class PasswordRecoveryDTORequest : DTORequest
    {
        [JsonProperty("hash")]
        public string Hash { get; set; }
        [JsonProperty("passwordHash")]
        public string PasswordHash { get; set; }

        public PasswordRecoveryDTORequest() : base(Method.POST)
        {
        }
    }
}
