using Newtonsoft.Json;

namespace R6DB_Bot.Models
{
    public class RookModel
    {

        [JsonProperty("won")]
        public int? won { get; set; }

        [JsonProperty("lost")]
        public int? lost { get; set; }

        [JsonProperty("kills")]
        public int? kills { get; set; }

        [JsonProperty("deaths")]
        public int? deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int? timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }
}
