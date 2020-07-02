using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.GoogleFit
{
    [JsonObject()]
    public class ListSessionsRequest
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }


        [JsonProperty("endTime")]
        public string EndTime { get; set; }

        [JsonProperty("includeDeleted")]
        public bool IncludeDeleted { get; set; }


        [JsonProperty("pageToken")]
        public string PageToken { get; set; }

        [JsonProperty("startTime")]
        public string StartTime { get; set; }
    }
}
