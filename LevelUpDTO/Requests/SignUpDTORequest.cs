using Newtonsoft.Json;
using System;

namespace LevelUpDTO
{
    [JsonObject()]
    public class SignUpDTORequest : DTORequest
    {
        [JsonProperty("login")]
        public string Login { get; set; }
        [JsonProperty("firstname")]
        public string Firstname { get; set; }
        [JsonProperty("lastname")]
        public string Lastname { get; set; }
        [JsonProperty("gender")]
        public bool? Gender { get; set; }
        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }
        [JsonProperty("passwordHash")]
        public string PasswordHash { get; set; }

        public SignUpDTORequest() : base(Method.POST)
        {

        }
    }
}
