using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.Dbo.GoogleFit
{
    [JsonObject()]
    public class Session
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("startTimeMillis")]
        public long StartTimeMillis { get; set; }

        [JsonProperty("endTimeMillis")]
        public long EndTimeMillis { get; set; }

        [JsonProperty("modifiedTimeMillis")]
        public long ModifiedTimeMillis { get; set; }
      
        [JsonProperty("application")]
        public Application Application { get; set; }


        [JsonProperty("activityType")]
        public int ActivityType { get; set; }
  
        [JsonProperty("activeTimeMillis")]
        public long ActiveTimeMillis { get; set; }
    }
}
