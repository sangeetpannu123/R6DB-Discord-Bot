using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace R6DB_Bot.Models
{
    public class LastPlayed
    {

        [JsonProperty("casual")]
        public int casual { get; set; }

        [JsonProperty("ranked")]
        public int ranked { get; set; }

        [JsonProperty("last_played")]
        public DateTime last_played { get; set; }
    }

    public class Apac
    {
        [JsonProperty("abandons")]
        public int abandons { get; set; }

        [JsonProperty("losses")]
        public int losses { get; set; }

        [JsonProperty("max_mmr")]
        public decimal max_mmr { get; set; }

        [JsonProperty("max_rank")]
        public int max_rank { get; set; }

        [JsonProperty("mmr")]
        public decimal mmr { get; set; }

        [JsonProperty("rank")]
        public int rank { get; set; }

        [JsonProperty("skill_mean")]
        public decimal skill_mean { get; set; }

        [JsonProperty("skill_stdev")]
        public decimal skill_stdev { get; set; }

        [JsonProperty("wins")]
        public int wins { get; set; }
    }

    public class Emea
    {
        [JsonProperty("abandons")]
        public int abandons { get; set; }

        [JsonProperty("losses")]
        public int losses { get; set; }

        [JsonProperty("max_mmr")]
        public decimal max_mmr { get; set; }

        [JsonProperty("max_rank")]
        public int max_rank { get; set; }

        [JsonProperty("mmr")]
        public decimal mmr { get; set; }

        [JsonProperty("rank")]
        public int rank { get; set; }

        [JsonProperty("skill_mean")]
        public decimal skill_mean { get; set; }

        [JsonProperty("skill_stdev")]
        public decimal skill_stdev { get; set; }

        [JsonProperty("wins")]
        public int wins { get; set; }
    }

    public class Ncsa
    {
        [JsonProperty("abandons")]
        public int abandons { get; set; }

        [JsonProperty("losses")]
        public int losses { get; set; }

        [JsonProperty("max_mmr")]
        public decimal max_mmr { get; set; }

        [JsonProperty("max_rank")]
        public int max_rank { get; set; }

        [JsonProperty("mmr")]
        public decimal mmr { get; set; }

        [JsonProperty("rank")]
        public int rank { get; set; }

        [JsonProperty("skill_mean")]
        public decimal skill_mean { get; set; }

        [JsonProperty("skill_stdev")]
        public decimal skill_stdev { get; set; }

        [JsonProperty("wins")]
        public int wins { get; set; }
    }

    public class RegionInfo
    {

        [JsonProperty("abandons")]
        public int abandons { get; set; }

        [JsonProperty("losses")]
        public int losses { get; set; }

        [JsonProperty("max_mmr")]
        public decimal max_mmr { get; set; }

        [JsonProperty("max_rank")]
        public int max_rank { get; set; }

        [JsonProperty("mmr")]
        public decimal mmr { get; set; }

        [JsonProperty("rank")]
        public int rank { get; set; }

        [JsonProperty("skill_mean")]
        public decimal skill_mean { get; set; }

        [JsonProperty("skill_stdev")]
        public decimal skill_stdev { get; set; }

        [JsonProperty("wins")]
        public int wins { get; set; }

        public void SetEURegionInfo(PlayerModel fullModel)
        {
            abandons    = fullModel?.rank?.emea?.abandons ?? 0;
            losses      = fullModel?.rank?.emea?.losses ?? 0;
            max_mmr     = fullModel?.rank?.emea?.max_mmr ?? 0;
            max_rank    = fullModel?.rank?.emea?.max_rank ?? 0;
            mmr         = fullModel?.rank?.emea?.mmr ?? 0;
            rank        = fullModel?.rank?.emea?.rank ?? 0;
            skill_stdev = fullModel?.rank?.emea?.skill_stdev ?? 0;
            skill_mean  = fullModel?.rank?.emea?.skill_mean ?? 0;
            wins        = fullModel?.rank?.emea?.wins ?? 0;
        }

        public void SetNARegionInfo(PlayerModel fullModel)
        {
            abandons    = fullModel?.rank?.ncsa?.abandons ?? 0;
            losses      = fullModel?.rank?.ncsa?.losses ?? 0;
            max_mmr     = fullModel?.rank?.ncsa?.max_mmr ?? 0;
            max_rank    = fullModel?.rank?.ncsa?.max_rank ?? 0;
            mmr         = fullModel?.rank?.ncsa?.mmr ?? 0;
            rank        = fullModel?.rank?.ncsa?.rank ?? 0;
            skill_stdev = fullModel?.rank?.ncsa?.skill_stdev ?? 0;
            skill_mean  = fullModel?.rank?.ncsa?.skill_mean ?? 0;
            wins        = fullModel?.rank?.ncsa?.wins ?? 0;
        }

        public void SetASIARegionInfo(PlayerModel fullModel)
        {
            abandons    = fullModel?.rank?.apac?.abandons ?? 0;
            losses      = fullModel?.rank?.apac?.losses ?? 0;
            max_mmr     = fullModel?.rank?.apac?.max_mmr ?? 0;
            max_rank    = fullModel?.rank?.apac?.max_rank ?? 0;
            mmr         = fullModel?.rank?.apac?.mmr ?? 0;
            rank        = fullModel?.rank?.apac?.rank ?? 0;
            skill_stdev = fullModel?.rank?.apac?.skill_stdev ?? 0;
            skill_mean  = fullModel?.rank?.apac?.skill_mean ?? 0;
            wins        = fullModel?.rank?.apac?.wins ?? 0;
        }
    }

    public class Rank
    {

        [JsonProperty("season")]
        public int season { get; set; }

        [JsonProperty("apac")]
        public Apac apac { get; set; }

        [JsonProperty("emea")]
        public Emea emea { get; set; }

        [JsonProperty("ncsa")]
        public Ncsa ncsa { get; set; }
    }

    public class SeasonRank
    {
        [JsonProperty("ncsa")]
        public Ncsa ncsa { get; set; }

        [JsonProperty("apac")]
        public Apac apac { get; set; }

        [JsonProperty("emea")]
        public Emea emea { get; set; }

        [JsonProperty("season")]
        public string season { get; set; }
    }

    public class Bomb
    {

        [JsonProperty("bestScore")]
        public int bestScore { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("played")]
        public int played { get; set; }

        [JsonProperty("won")]
        public int won { get; set; }
    }

    public class Casual
    {

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("played")]
        public int played { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("won")]
        public int won { get; set; }
    }

    public class Custom
    {

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }
    }

    public class General
    {

        [JsonProperty("assists")]
        public int assists { get; set; }

        [JsonProperty("blindKills")]
        public int blindKills { get; set; }

        [JsonProperty("bulletsFired")]
        public int bulletsFired { get; set; }

        [JsonProperty("bulletsHit")]
        public int bulletsHit { get; set; }

        [JsonProperty("dbno")]
        public int dbno { get; set; }

        [JsonProperty("dbnoAssists")]
        public int dbnoAssists { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("gadgetsDestroyed")]
        public int gadgetsDestroyed { get; set; }

        [JsonProperty("headshot")]
        public int headshot { get; set; }

        [JsonProperty("hostageDefense")]
        public int hostageDefense { get; set; }

        [JsonProperty("hostageRescue")]
        public int hostageRescue { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("meleeKills")]
        public int meleeKills { get; set; }

        [JsonProperty("penetrationKills")]
        public int penetrationKills { get; set; }

        [JsonProperty("played")]
        public int played { get; set; }

        [JsonProperty("rappelBreaches")]
        public int rappelBreaches { get; set; }

        [JsonProperty("revives")]
        public int revives { get; set; }

        [JsonProperty("revivesDenied")]
        public int revivesDenied { get; set; }

        [JsonProperty("serverAggression")]
        public int serverAggression { get; set; }

        [JsonProperty("serverDefender")]
        public int serverDefender { get; set; }

        [JsonProperty("serversHacked")]
        public int serversHacked { get; set; }

        [JsonProperty("suicides")]
        public int suicides { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("won")]
        public int won { get; set; }
    }

    public class Hostage
    {

        [JsonProperty("bestScore")]
        public int bestScore { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("played")]
        public int played { get; set; }

        [JsonProperty("won")]
        public int won { get; set; }
    }

    public class Iq
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Ash
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Doc
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Ela
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Buck
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Echo
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Fuze
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Glaz
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Mira
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Mute
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Rook
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Ying
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Blitz
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Frost
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Jager
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Pulse
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Smoke
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Vigil
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Zofia
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Bandit
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Castle
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Hibana
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Jackal
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Kapkan
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Lesion
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Sledge
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Twitch
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Capitao
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Caveira
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Dokkaebi
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Montagne
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Recruit1
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Recruit2
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Recruit3
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Recruit4
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Recruit5
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Tachanka
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Thatcher
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Thermite
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Valkyrie
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Blackbeard
    {

        [JsonProperty("won")]
        public int won { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Operator
    {

        [JsonProperty("iq")]
        public Iq iq { get; set; }

        [JsonProperty("ash")]
        public Ash ash { get; set; }

        [JsonProperty("doc")]
        public Doc doc { get; set; }

        [JsonProperty("ela")]
        public Ela ela { get; set; }

        [JsonProperty("buck")]
        public Buck buck { get; set; }

        [JsonProperty("echo")]
        public Echo echo { get; set; }

        [JsonProperty("fuze")]
        public Fuze fuze { get; set; }

        [JsonProperty("glaz")]
        public Glaz glaz { get; set; }

        [JsonProperty("mira")]
        public Mira mira { get; set; }

        [JsonProperty("mute")]
        public Mute mute { get; set; }

        [JsonProperty("rook")]
        public Rook rook { get; set; }

        [JsonProperty("ying")]
        public Ying ying { get; set; }

        [JsonProperty("blitz")]
        public Blitz blitz { get; set; }

        [JsonProperty("frost")]
        public Frost frost { get; set; }

        [JsonProperty("jager")]
        public Jager jager { get; set; }

        [JsonProperty("pulse")]
        public Pulse pulse { get; set; }

        [JsonProperty("smoke")]
        public Smoke smoke { get; set; }

        [JsonProperty("vigil")]
        public Vigil vigil { get; set; }

        [JsonProperty("zofia")]
        public Zofia zofia { get; set; }

        [JsonProperty("bandit")]
        public Bandit bandit { get; set; }

        [JsonProperty("castle")]
        public Castle castle { get; set; }

        [JsonProperty("hibana")]
        public Hibana hibana { get; set; }

        [JsonProperty("jackal")]
        public Jackal jackal { get; set; }

        [JsonProperty("kapkan")]
        public Kapkan kapkan { get; set; }

        [JsonProperty("lesion")]
        public Lesion lesion { get; set; }

        [JsonProperty("sledge")]
        public Sledge sledge { get; set; }

        [JsonProperty("twitch")]
        public Twitch twitch { get; set; }

        [JsonProperty("capitao")]
        public Capitao capitao { get; set; }

        [JsonProperty("caveira")]
        public Caveira caveira { get; set; }

        [JsonProperty("dokkaebi")]
        public Dokkaebi dokkaebi { get; set; }

        [JsonProperty("montagne")]
        public Montagne montagne { get; set; }

        [JsonProperty("recruit1")]
        public Recruit1 recruit1 { get; set; }

        [JsonProperty("recruit2")]
        public Recruit2 recruit2 { get; set; }

        [JsonProperty("recruit3")]
        public Recruit3 recruit3 { get; set; }

        [JsonProperty("recruit4")]
        public Recruit4 recruit4 { get; set; }

        [JsonProperty("recruit5")]
        public Recruit5 recruit5 { get; set; }

        [JsonProperty("tachanka")]
        public Tachanka tachanka { get; set; }

        [JsonProperty("thatcher")]
        public Thatcher thatcher { get; set; }

        [JsonProperty("thermite")]
        public Thermite thermite { get; set; }

        [JsonProperty("valkyrie")]
        public Valkyrie valkyrie { get; set; }

        [JsonProperty("blackbeard")]
        public Blackbeard blackbeard { get; set; }
    }

    public class Ranked
    {

        [JsonProperty("deaths")]
        public int deaths { get; set; }

        [JsonProperty("kills")]
        public int kills { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("played")]
        public int played { get; set; }

        [JsonProperty("timePlayed")]
        public int timePlayed { get; set; }

        [JsonProperty("won")]
        public int won { get; set; }
    }

    public class Secure
    {

        [JsonProperty("bestScore")]
        public int bestScore { get; set; }

        [JsonProperty("lost")]
        public int lost { get; set; }

        [JsonProperty("played")]
        public int played { get; set; }

        [JsonProperty("won")]
        public int won { get; set; }
    }

    public class Stats
    {

        [JsonProperty("bomb")]
        public Bomb bomb { get; set; }

        [JsonProperty("casual")]
        public Casual casual { get; set; }

        [JsonProperty("custom")]
        public Custom custom { get; set; }

        [JsonProperty("general")]
        public General general { get; set; }

        [JsonProperty("hostage")]
        public Hostage hostage { get; set; }

        [JsonProperty("operator")]
        public Operator Operator{ get; set; }

        [JsonProperty("ranked")]
        public Ranked ranked { get; set; }

        [JsonProperty("secure")]
        public Secure secure { get; set; }
    }

    public class Placements
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

    public class Ranks
    {

        [JsonProperty("apac")]
        public Apac apac { get; set; }

        [JsonProperty("emea")]
        public Emea emea { get; set; }

        [JsonProperty("ncsa")]
        public Ncsa ncsa { get; set; }
    }

    public class Progression
    {

        [JsonProperty("created_at")]
        public DateTime created_at { get; set; }

        [JsonProperty("updated_at")]
        public DateTime updated_at { get; set; }

        [JsonProperty("placements")]
        public Placements placements { get; set; }

        [JsonProperty("ranks")]
        public Ranks ranks { get; set; }

        [JsonProperty("stats")]
        public Stats stats { get; set; }
    }

    public class Alias
    {

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("created_at")]
        public DateTime created_at { get; set; }
    }

    public class PlayerModel
    {

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("userId")]
        public object userId { get; set; }

        [JsonProperty("platform")]
        public string platform { get; set; }

        [JsonProperty("flair")]
        public object flair { get; set; }

        [JsonProperty("level")]
        public int level { get; set; }

        [JsonProperty("created_at")]
        public DateTime created_at { get; set; }

        [JsonProperty("updated_at")]
        public DateTime updated_at { get; set; }

        [JsonProperty("lastPlayed")]
        public LastPlayed lastPlayed { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("rank")]
        public Rank rank { get; set; }
        
        [JsonProperty("seasonRanks")]
        public IList<SeasonRank> seasonRanks { get; set; }

        [JsonProperty("stats")]
        public Stats stats { get; set; }

        [JsonProperty("placements")]
        public Placements placements { get; set; }

        [JsonProperty("progressions")]
        public IList<Progression> progressions { get; set; }

        [JsonProperty("aliases")]
        public IList<Alias> aliases { get; set; }

        [JsonProperty("serverTime")]
        public DateTime serverTime { get; set; }

        [JsonProperty("updateAvailableAt")]
        public DateTime updateAvailableAt { get; set; }
    }
}
