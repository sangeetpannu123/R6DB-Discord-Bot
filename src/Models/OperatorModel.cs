using Newtonsoft.Json;

namespace R6DB_Bot.Models
{
    public class OperatorModel
    {

        [JsonProperty("iq")]
        public IqModel iq { get; set; }

        [JsonProperty("ash")]
        public AshModel ash { get; set; }

        [JsonProperty("doc")]
        public DocModel doc { get; set; }

        [JsonProperty("ela")]
        public ElaModel ela { get; set; }

        [JsonProperty("buck")]
        public BuckModel buck { get; set; }

        [JsonProperty("echo")]
        public EchoModel echo { get; set; }

        [JsonProperty("fuze")]
        public FuzeModel fuze { get; set; }

        [JsonProperty("glaz")]
        public GlazModel glaz { get; set; }

        [JsonProperty("mira")]
        public MiraModel mira { get; set; }

        [JsonProperty("mute")]
        public MuteModel mute { get; set; }

        [JsonProperty("rook")]
        public RookModel rook { get; set; }

        [JsonProperty("ying")]
        public YingModel ying { get; set; }

        [JsonProperty("blitz")]
        public BlitzModel blitz { get; set; }

        [JsonProperty("frost")]
        public FrostModel frost { get; set; }

        [JsonProperty("jager")]
        public JagerModel jager { get; set; }

        [JsonProperty("pulse")]
        public PulseModel pulse { get; set; }

        [JsonProperty("smoke")]
        public SmokeModel smoke { get; set; }

        [JsonProperty("vigil")]
        public VigilModel vigil { get; set; }

        [JsonProperty("zofia")]
        public ZofiaModel zofia { get; set; }

        [JsonProperty("bandit")]
        public BanditModel bandit { get; set; }

        [JsonProperty("castle")]
        public CastleModel castle { get; set; }

        [JsonProperty("hibana")]
        public HibanaModel hibana { get; set; }

        [JsonProperty("jackal")]
        public JackalModel jackal { get; set; }

        [JsonProperty("kapkan")]
        public KapkanModel kapkan { get; set; }

        [JsonProperty("lesion")]
        public LesionModel lesion { get; set; }

        [JsonProperty("sledge")]
        public SledgeModel sledge { get; set; }

        [JsonProperty("twitch")]
        public TwitchModel twitch { get; set; }

        [JsonProperty("capitao")]
        public CapitaoModel capitao { get; set; }

        [JsonProperty("caveira")]
        public CaveiraModel caveira { get; set; }

        [JsonProperty("dokkaebi")]
        public DokkaebiModel dokkaebi { get; set; }

        [JsonProperty("montagne")]
        public MontagneModel montagne { get; set; }

        [JsonProperty("recruit1")]
        public Recruit1Model recruit1 { get; set; }

        [JsonProperty("recruit2")]
        public Recruit2Model recruit2 { get; set; }

        [JsonProperty("recruit3")]
        public Recruit3Model recruit3 { get; set; }

        [JsonProperty("recruit4")]
        public Recruit4Model recruit4 { get; set; }

        [JsonProperty("recruit5")]
        public Recruit5Model recruit5 { get; set; }

        [JsonProperty("tachanka")]
        public TachankaModel tachanka { get; set; }

        [JsonProperty("thatcher")]
        public ThatcherModel thatcher { get; set; }

        [JsonProperty("thermite")]
        public ThermiteModel thermite { get; set; }

        [JsonProperty("valkyrie")]
        public ValkyrieModel valkyrie { get; set; }

        [JsonProperty("blackbeard")]
        public BlackbeardModel blackbeard { get; set; }
    }
}
