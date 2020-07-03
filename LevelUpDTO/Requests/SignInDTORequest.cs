using Newtonsoft.Json;
using System;

namespace LevelUpDTO
{
    [JsonObject()]
    public class SignInDTORequest : DTORequest
    {
        [JsonProperty("login")]
        public string Login { get; set; }
        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }
        [JsonProperty("passwordHash")]
        public string PasswordHash { get; set; }

        public SignInDTORequest() : base(Method.POST)
        {
        }
    }
}
