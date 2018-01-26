using Newtonsoft.Json;

namespace R6DB_Bot.Models
{
    public class SeasonRankModel
    {
        [JsonProperty("ncsa")]
        public NcsaModel ncsa { get; set; }

        [JsonProperty("apac")]
        public ApacModel apac { get; set; }

        [JsonProperty("emea")]
        public EmeaModel emea { get; set; }

        [JsonProperty("season")]
        public string season { get; set; }
    }
}
