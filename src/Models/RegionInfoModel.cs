using Newtonsoft.Json;

namespace R6DB_Bot.Models
{
    public class RegionInfoModel
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

        public void SetHighestRegion(PlayerModel model)
        {
            var EU_MMR = model?.rank?.emea?.mmr ?? 0;
            var NA_MMR = model?.rank?.ncsa?.mmr ?? 0;
            var ASIA_MMR = model?.rank?.apac?.mmr ?? 0;

            if (EU_MMR > NA_MMR)
            {
                if (EU_MMR > ASIA_MMR)
                {
                    SetEURegionInfo(model);
                } else
                {
                    SetASIARegionInfo(model);
                }
            }
            else
            {
                if (NA_MMR > ASIA_MMR)
                {
                    SetNARegionInfo(model);
                }
                else
                {
                    SetASIARegionInfo(model);
                }
            }
        }
    }
}
