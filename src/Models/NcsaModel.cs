using Newtonsoft.Json;

namespace R6DB_Bot.Models
{
    public class NcsaModel
    {
        [JsonProperty("abandons")]
        public int? abandons { get; set; }

        [JsonProperty("losses")]
        public int? losses { get; set; }

        [JsonProperty("max_mmr")]
        public decimal? max_mmr { get; set; }

        [JsonProperty("max_rank")]
        public int? max_rank { get; set; }

        [JsonProperty("mmr")]
        public decimal? mmr { get; set; }

        [JsonProperty("rank")]
        public int? rank { get; set; }

        [JsonProperty("skill_mean")]
        public decimal? skill_mean { get; set; }

        [JsonProperty("skill_stdev")]
        public decimal? skill_stdev { get; set; }

        [JsonProperty("wins")]
        public int? wins { get; set; }
    }
}
