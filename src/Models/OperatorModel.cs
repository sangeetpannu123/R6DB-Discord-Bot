using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

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

        public List<OperatorInfoModel> GetAllAttackOperators()
        {
            var operators = new List<OperatorInfoModel>
            {
                new OperatorInfoModel
                {
                    deaths = iq.deaths,
                    kills = iq.kills,
                    lost = iq.lost,
                    won = iq.won,
                    name = iq.name,
                    timePlayed = iq.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = ash.deaths,
                    kills = ash.kills,
                    lost = ash.lost,
                    won = ash.won,
                    name = ash.name,
                    timePlayed = ash.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = buck.deaths,
                    kills = buck.kills,
                    lost = buck.lost,
                    won = buck.won,
                    name = buck.name,
                    timePlayed = buck.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = fuze.deaths,
                    kills = fuze.kills,
                    lost = fuze.lost,
                    won = fuze.won,
                    name = fuze.name,
                    timePlayed = fuze.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = glaz.deaths,
                    kills = glaz.kills,
                    lost = glaz.lost,
                    won = glaz.won,
                    name = glaz.name,
                    timePlayed = glaz.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = ying.deaths,
                    kills = ying.kills,
                    lost = ying.lost,
                    won = ying.won,
                    name = ying.name,
                    timePlayed = ying.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = blitz.deaths,
                    kills = blitz.kills,
                    lost = blitz.lost,
                    won = blitz.won,
                    name = blitz.name,
                    timePlayed = blitz.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = zofia.deaths,
                    kills = zofia.kills,
                    lost = zofia.lost,
                    won = zofia.won,
                    name = zofia.name,
                    timePlayed = zofia.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = hibana.deaths,
                    kills = hibana.kills,
                    lost = hibana.lost,
                    won = hibana.won,
                    name = hibana.name,
                    timePlayed = hibana.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = jackal.deaths,
                    kills = jackal.kills,
                    lost = jackal.lost,
                    won = jackal.won,
                    name = jackal.name,
                    timePlayed = jackal.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = sledge.deaths,
                    kills = sledge.kills,
                    lost = sledge.lost,
                    won = sledge.won,
                    name = sledge.name,
                    timePlayed = sledge.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = twitch.deaths,
                    kills = twitch.kills,
                    lost = twitch.lost,
                    won = twitch.won,
                    name = twitch.name,
                    timePlayed = twitch.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = capitao.deaths,
                    kills = capitao.kills,
                    lost = capitao.lost,
                    won = capitao.won,
                    name = capitao.name,
                    timePlayed = capitao.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = dokkaebi.deaths,
                    kills = dokkaebi.kills,
                    lost = dokkaebi.lost,
                    won = dokkaebi.won,
                    name = dokkaebi.name,
                    timePlayed = dokkaebi.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = montagne.deaths,
                    kills = montagne.kills,
                    lost = montagne.lost,
                    won = montagne.won,
                    name = montagne.name,
                    timePlayed = montagne.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = recruit1.deaths,
                    kills = recruit1.kills,
                    lost = recruit1.lost,
                    won = recruit1.won,
                    name = recruit1.name,
                    timePlayed = recruit1.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = recruit2.deaths,
                    kills = recruit2.kills,
                    lost = recruit2.lost,
                    won = recruit2.won,
                    name = recruit2.name,
                    timePlayed = recruit2.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = recruit3.deaths,
                    kills = recruit3.kills,
                    lost = recruit3.lost,
                    won = recruit3.won,
                    name = recruit3.name,
                    timePlayed = recruit3.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = recruit4.deaths,
                    kills = recruit4.kills,
                    lost = recruit4.lost,
                    won = recruit4.won,
                    name = recruit4.name,
                    timePlayed = recruit4.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = recruit5.deaths,
                    kills = recruit5.kills,
                    lost = recruit5.lost,
                    won = recruit5.won,
                    name = recruit5.name,
                    timePlayed = recruit5.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = thatcher.deaths,
                    kills = thatcher.kills,
                    lost = thatcher.lost,
                    won = thatcher.won,
                    name = thatcher.name,
                    timePlayed = thatcher.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = thermite.deaths,
                    kills = thermite.kills,
                    lost = thermite.lost,
                    won = thermite.won,
                    name = thermite.name,
                    timePlayed = thermite.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = blackbeard.deaths,
                    kills = blackbeard.kills,
                    lost = blackbeard.lost,
                    won = blackbeard.won,
                    name = blackbeard.name,
                    timePlayed = blackbeard.timePlayed
                }
            };


            return operators;
        }

        public List<OperatorInfoModel> GetAllDefendOperators()
        {
            var operators = new List<OperatorInfoModel>
            {
                new OperatorInfoModel
                {
                    deaths = doc.deaths,
                    kills = doc.kills,
                    lost = doc.lost,
                    won = doc.won,
                    name = doc.name,
                    timePlayed = doc.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = ela.deaths,
                    kills = ela.kills,
                    lost = ela.lost,
                    won = ela.won,
                    name = ela.name,
                    timePlayed = ela.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = echo.deaths,
                    kills = echo.kills,
                    lost = echo.lost,
                    won = echo.won,
                    name = echo.name,
                    timePlayed = echo.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = mira.deaths,
                    kills = mira.kills,
                    lost = mira.lost,
                    won = mira.won,
                    name = mira.name,
                    timePlayed = mira.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = mute.deaths,
                    kills = mute.kills,
                    lost = mute.lost,
                    won = mute.won,
                    name = mute.name,
                    timePlayed = mute.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = rook.deaths,
                    kills = rook.kills,
                    lost = rook.lost,
                    won = rook.won,
                    name = rook.name,
                    timePlayed = rook.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = frost.deaths,
                    kills = frost.kills,
                    lost = frost.lost,
                    won = frost.won,
                    name = frost.name,
                    timePlayed = frost.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = jager.deaths,
                    kills = jager.kills,
                    lost = jager.lost,
                    won = jager.won,
                    name = jager.name,
                    timePlayed = jager.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = pulse.deaths,
                    kills = pulse.kills,
                    lost = pulse.lost,
                    won = pulse.won,
                    name = pulse.name,
                    timePlayed = pulse.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = smoke.deaths,
                    kills = smoke.kills,
                    lost = smoke.lost,
                    won = smoke.won,
                    name = smoke.name,
                    timePlayed = smoke.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = vigil.deaths,
                    kills = vigil.kills,
                    lost = vigil.lost,
                    won = vigil.won,
                    name = vigil.name,
                    timePlayed = vigil.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = bandit.deaths,
                    kills = bandit.kills,
                    lost = bandit.lost,
                    won = bandit.won,
                    name = bandit.name,
                    timePlayed = bandit.timePlayed
                },
                new OperatorInfoModel
                {
                    deaths = castle.deaths,
                    kills = castle.kills,
                    lost = castle.lost,
                    won = castle.won,
                    name = castle.name,
                    timePlayed = castle.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = kapkan.deaths,
                    kills = kapkan.kills,
                    lost = kapkan.lost,
                    won = kapkan.won,
                    name = kapkan.name,
                    timePlayed = kapkan.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = lesion.deaths,
                    kills = lesion.kills,
                    lost = lesion.lost,
                    won = lesion.won,
                    name = lesion.name,
                    timePlayed = lesion.timePlayed
                },
                new OperatorInfoModel
                {
                    deaths = caveira.deaths,
                    kills = caveira.kills,
                    lost = caveira.lost,
                    won = caveira.won,
                    name = caveira.name,
                    timePlayed = caveira.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = dokkaebi.deaths,
                    kills = dokkaebi.kills,
                    lost = dokkaebi.lost,
                    won = dokkaebi.won,
                    name = dokkaebi.name,
                    timePlayed = dokkaebi.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = recruit1.deaths,
                    kills = recruit1.kills,
                    lost = recruit1.lost,
                    won = recruit1.won,
                    name = recruit1.name,
                    timePlayed = recruit1.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = recruit2.deaths,
                    kills = recruit2.kills,
                    lost = recruit2.lost,
                    won = recruit2.won,
                    name = recruit2.name,
                    timePlayed = recruit2.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = recruit3.deaths,
                    kills = recruit3.kills,
                    lost = recruit3.lost,
                    won = recruit3.won,
                    name = recruit3.name,
                    timePlayed = recruit3.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = recruit4.deaths,
                    kills = recruit4.kills,
                    lost = recruit4.lost,
                    won = recruit4.won,
                    name = recruit4.name,
                    timePlayed = recruit4.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = recruit5.deaths,
                    kills = recruit5.kills,
                    lost = recruit5.lost,
                    won = recruit5.won,
                    name = recruit5.name,
                    timePlayed = recruit5.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = tachanka.deaths,
                    kills = tachanka.kills,
                    lost = tachanka.lost,
                    won = tachanka.won,
                    name = tachanka.name,
                    timePlayed = tachanka.timePlayed
                },

                new OperatorInfoModel
                {
                    deaths = valkyrie.deaths,
                    kills = valkyrie.kills,
                    lost = valkyrie.lost,
                    won = valkyrie.won,
                    name = valkyrie.name,
                    timePlayed = valkyrie.timePlayed
                }
            };


            return operators;
        }
    }
}
