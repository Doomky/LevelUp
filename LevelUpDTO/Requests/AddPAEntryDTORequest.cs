using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    [JsonObject()]
    public class AddPAEntryDTORequest : DTORequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("dateTimeStart")]
        public string DateTimeStart { get; set; }
        [JsonProperty("dateTimeEnd")]
        public string DateTimeEnd { get; set; }

        public AddPAEntryDTORequest() : base(Method.POST)
        {
        }
    }
}
