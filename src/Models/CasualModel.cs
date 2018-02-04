using Newtonsoft.Json;

namespace R6DB_Bot.Models
{
    public class CasualModel
    {

        [JsonProperty("deaths")]
        public int? deaths { get; set; }

        [JsonProperty("kills")]
        public int? kills { get; set; }

        [JsonProperty("lost")]
        public int? lost { get; set; }

        [JsonProperty("played")]
        public int? played { get; set; }

        [JsonProperty("timePlayed")]
        public int? timePlayed { get; set; }

        [JsonProperty("won")]
        public int? won { get; set; }
    }
}
