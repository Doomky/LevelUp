using Newtonsoft.Json;
using System;

namespace LevelUpDTO
{
    [JsonObject()]
    public class ForgotPasswordDTORequest : DTORequest
    {
        [JsonProperty("login")]
        public string Login { get; set; }
        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }
        public ForgotPasswordDTORequest() : base(Method.POST)
        {
        }
    }
}
