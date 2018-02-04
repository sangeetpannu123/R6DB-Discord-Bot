using Newtonsoft.Json;
using System;

namespace R6DB_Bot.Models
{
    public class AliasModel
    {

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("created_at")]
        public DateTime? created_at { get; set; }
    }
}
