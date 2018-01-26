using Newtonsoft.Json;

namespace R6DB_Bot.Models
{
    public class PlacementsModel
    {

        [JsonProperty("global")]
        public int? global { get; set; }

        [JsonProperty("emea")]
        public int? emea { get; set; }

        [JsonProperty("ncsa")]
        public int? ncsa { get; set; }

        [JsonProperty("apac")]
        public int? apac { get; set; }
    }
}
