using Newtonsoft.Json;

namespace R6DB_Bot.Models
{
    public class RankModel
    {

        [JsonProperty("season")]
        public int? season { get; set; }

        [JsonProperty("apac")]
        public ApacModel apac { get; set; }

        [JsonProperty("emea")]
        public EmeaModel emea { get; set; }

        [JsonProperty("ncsa")]
        public NcsaModel ncsa { get; set; }
    }
}
