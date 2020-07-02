using LevelUpAPI.Dbo.GoogleFit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.GoogleFit
{
    [JsonObject()]
    public class ListSessionstResponse
    {
        [JsonProperty("session")]
        public List<Session> Sessions { get; set; }

        [JsonProperty("deletedSession")]
        public List<Session> DeletedSession { get; set; }

        [JsonProperty("nextPageToken")]
        public string NextPageToken { get; set; }

        [JsonProperty("hasMoreData")]
        public bool HasMoreData { get; set; }
    }
}
