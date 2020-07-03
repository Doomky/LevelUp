
using Newtonsoft.Json;

namespace LevelUpDTO
{
    [JsonObject()]
    public class SignOutDTORequest : DTORequest
    {
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }

        public SignOutDTORequest() : base(Method.POST)
        {
        }
    }
}
