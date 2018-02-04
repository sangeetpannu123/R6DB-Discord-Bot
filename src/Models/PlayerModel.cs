using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace R6DB_Bot.Models
{
    public class PlayerModel
    {

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("userId")]
        public string userId { get; set; }

        [JsonProperty("platform")]
        public string platform { get; set; }

        [JsonProperty("flair")]
        public object flair { get; set; }

        [JsonProperty("level")]
        public int? level { get; set; }

        [JsonProperty("active")]
        public bool? active { get; set; }

        [JsonProperty("created_at")]
        public DateTime? created_at { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? updated_at { get; set; }

        [JsonProperty("lastPlayed")]
        public LastPlayedModel lastPlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("rank")]
        public RankModel rank { get; set; }
        
        [JsonProperty("seasonRanks")]
        public IList<SeasonRankModel> seasonRanks { get; set; }

        [JsonProperty("stats")]
        public StatsModel stats { get; set; }

        [JsonProperty("placements")]
        public PlacementsModel placements { get; set; }

        [JsonProperty("progressions")]
        public IList<ProgressionModel> progressions { get; set; }

        [JsonProperty("aliases")]
        public IList<AliasModel> aliases { get; set; }

        [JsonProperty("serverTime")]
        public DateTime? serverTime { get; set; }

        [JsonProperty("updateAvailableAt")]
        public DateTime? updateAvailableAt { get; set; }

        [JsonIgnore]
        public GuessedModel guessed { get; set; }
    }
}
