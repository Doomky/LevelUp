using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    [JsonObject()]
    public class AddPADTORequest : DTORequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("calPerKgPerHour")]
        public double? CalPerKgPerHour { get; set; }

        public AddPADTORequest() : base(Method.POST)
        {
        }
    }
}
