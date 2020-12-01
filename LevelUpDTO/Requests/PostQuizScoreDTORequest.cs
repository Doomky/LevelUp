using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO.Requests
{
    public class PostQuizScoreDTORequest : DTORequest
    {
        [JsonProperty("login")]
        public string Login { get; set; }
        [JsonProperty("score")]
        public int Score { get; set; }

        public PostQuizScoreDTORequest() : base(Method.POST)
        {
        }
    }
}
