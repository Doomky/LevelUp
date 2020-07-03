using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    [JsonObject()]
    public class ClientCredentialsDTORequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("login")]
        public string Login { get; set; }
        [JsonProperty("passwordHash")]
        public string PasswordHash { get; set; }
    }
}
