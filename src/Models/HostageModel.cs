using Newtonsoft.Json;

namespace R6DB_Bot.Models
{
    public class HostageModel
    {

        [JsonProperty("bestScore")]
        public int? bestScore { get; set; }

        [JsonProperty("lost")]
        public int? lost { get; set; }

        [JsonProperty("played")]
        public int? played { get; set; }

        [JsonProperty("won")]
        public int? won { get; set; }
    }
}
