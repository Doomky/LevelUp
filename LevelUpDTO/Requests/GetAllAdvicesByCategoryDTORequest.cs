using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO.Requests
{
    public class GetAllAdvicesByCategoryDTORequest : DTORequest
    {
        [JsonProperty]
        public string Category { get; set; }

        public GetAllAdvicesByCategoryDTORequest() : base(DTORequest.Method.GET)
        {
        }
    }
}
