using Newtonsoft.Json;
using System;

namespace R6DB_Bot.Models
{
    public class ProgressionModel
    {

        [JsonProperty("created_at")]
        public DateTime? created_at { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? updated_at { get; set; }

        [JsonProperty("placements")]
        public PlacementsModel placements { get; set; }

        [JsonProperty("ranks")]
        public RanksModel ranks { get; set; }

        [JsonProperty("stats")]
        public StatsModel stats { get; set; }
    }
}
