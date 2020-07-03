using Newtonsoft.Json;
using System;

namespace LevelUpDTO
{
    [JsonObject]
    public class ChangePasswordDTORequest : DTORequest
    {
        [JsonProperty("passwordHash")]
        public string PasswordHash { get; set; }
        [JsonProperty("newPasswordHash")]
        public string NewPasswordHash { get; set; }
        public ChangePasswordDTORequest() : base(Method.POST)
        {
        }
    }
}
