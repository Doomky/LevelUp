using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    [JsonObject()]
    public class UpdatePAEntryDTORequest : DTORequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("newDateTimeStart")]
        public DateTime NewDateTimeStart { get; set; }
        [JsonProperty("newDateTimeEnd")]
        public DateTime NewDateTimeEnd { get; set; }

        public UpdatePAEntryDTORequest() : base(Method.POST)
        {
        }
    }
}
