using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO.Requests
{
    [JsonObject()]
    public class GetAdviceByCategoryDTORequest : DTORequest
    {
        [JsonProperty]
        public string Category { get; set; }

        public GetAdviceByCategoryDTORequest() : base(Method.GET)
        {
        }
    }
}
