using Newtonsoft.Json;

namespace R6DB_Bot.Models
{
    public class StatsModel
    {

        [JsonProperty("bomb")]
        public BombModel bomb { get; set; }

        [JsonProperty("casual")]
        public CasualModel casual { get; set; }

        [JsonProperty("custom")]
        public CustomModel custom { get; set; }

        [JsonProperty("general")]
        public GeneralModel general { get; set; }

        [JsonProperty("hostage")]
        public HostageModel hostage { get; set; }

        [JsonProperty("operator")]
        public OperatorModel Operator{ get; set; }

        [JsonProperty("ranked")]
        public RankedModel ranked { get; set; }

        [JsonProperty("secure")]
        public SecureModel secure { get; set; }
    }
}
