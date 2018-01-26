using Newtonsoft.Json;

namespace R6DB_Bot.Models
{
    public class GeneralModel
    {

        [JsonProperty("assists")]
        public int? assists { get; set; }

        [JsonProperty("blindKills")]
        public int? blindKills { get; set; }

        [JsonProperty("bulletsFired")]
        public int? bulletsFired { get; set; }

        [JsonProperty("bulletsHit")]
        public int? bulletsHit { get; set; }

        [JsonProperty("dbno")]
        public int? dbno { get; set; }

        [JsonProperty("dbnoAssists")]
        public int? dbnoAssists { get; set; }

        [JsonProperty("deaths")]
        public int? deaths { get; set; }

        [JsonProperty("gadgetsDestroyed")]
        public int? gadgetsDestroyed { get; set; }

        [JsonProperty("headshot")]
        public int? headshot { get; set; }

        [JsonProperty("hostageDefense")]
        public int? hostageDefense { get; set; }

        [JsonProperty("hostageRescue")]
        public int? hostageRescue { get; set; }

        [JsonProperty("kills")]
        public int? kills { get; set; }

        [JsonProperty("lost")]
        public int? lost { get; set; }

        [JsonProperty("meleeKills")]
        public int? meleeKills { get; set; }

        [JsonProperty("penetrationKills")]
        public int? penetrationKills { get; set; }

        [JsonProperty("played")]
        public int? played { get; set; }

        [JsonProperty("rappelBreaches")]
        public int? rappelBreaches { get; set; }

        [JsonProperty("revives")]
        public int? revives { get; set; }

        [JsonProperty("revivesDenied")]
        public int? revivesDenied { get; set; }

        [JsonProperty("serverAggression")]
        public int? serverAggression { get; set; }

        [JsonProperty("serverDefender")]
        public int? serverDefender { get; set; }

        [JsonProperty("serversHacked")]
        public int? serversHacked { get; set; }

        [JsonProperty("suicides")]
        public int? suicides { get; set; }

        [JsonProperty("timePlayed")]
        public int? timePlayed { get; set; }

        [JsonProperty("won")]
        public int? won { get; set; }
    }
}
