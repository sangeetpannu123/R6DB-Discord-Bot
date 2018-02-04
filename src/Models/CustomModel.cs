using Newtonsoft.Json;

namespace R6DB_Bot.Models
{
    public class CustomModel
    {

        [JsonProperty("timePlayed")]
        public int? timePlayed { get; set; }
    }
}
