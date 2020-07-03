using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    [JsonObject()]
    public class LinkGoogleAccountDTORequest : DTORequest
    {
        [JsonProperty("googleAuthCode")]
        public string GoogleAuthCode { get; set; }
        public LinkGoogleAccountDTORequest() : base(Method.POST)
        {

        }
    }
}
