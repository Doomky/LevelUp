using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.Dbo.GoogleFit
{
    [JsonObject]
    public class Application
    {
        [JsonProperty("packageName")]
        public string PackageName { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("detailUrl")]
        public string DetailUrl { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
