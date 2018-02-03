using Discord;
using Discord.Commands;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using R6DB_Bot.Models;
using R6DB_Bot.Extensions;
using R6DB_Bot.Enums;
using System.Text.RegularExpressions;
using R6DB_Bot.Services;

namespace R6DB_Bot.Modules
{
    [Name("Ranked Information")]
    public class RankedModule : ModuleBase<SocketCommandContext>
    {
        public string baseUrl = "";
        public string xAppId = "";

        private readonly CommandService _service;
        private readonly IConfigurationRoot _config;
        private static string Prefix = "!";

        private RegionEnum regionEnum;
        private PlatformEnum platformEnum;

        public RankedModule(CommandService service, IConfigurationRoot config)
        {
            _service = service;
            _config = config;

            baseUrl = _config["r6db_url"];
            xAppId = _config["x-app-id"];

            regionEnum = RegionEnum.EMEA;
            platformEnum = PlatformEnum.PC;
        }

        [Command("ranked eu"), Alias("rank eu", "r eu"), Name("Rank Europe")]
        [Priority(1)]
        [Summary("Get rank statistics")]
        public async Task GetEURanks([Remainder]string text)
        {
            regionEnum = RegionEnum.EMEA;
            await GetRanks(text);
        }

        [Command("ranked eu pc"), Alias("rank eu pc", "r eu pc"), Name("Rank PC Europe")]
        [Priority(2)]
        [Summary("Get EU PC rank statistics")]
        public async Task GetEUPCRanks([Remainder]string text)
        {
            regionEnum = RegionEnum.EMEA;
            platformEnum = PlatformEnum.PC;
            await GetRanks(text);
        }

        [Command("ranked eu xbox"), Alias("rank eu xbox", "r eu xbox"), Name("Rank XBOX Europe")]
        [Priority(2)]
        [Summary("Get EU XBOX rank statistics")]
        public async Task GetEUXBOXRanks([Remainder]string text)
        {
            regionEnum = RegionEnum.EMEA;
            platformEnum = PlatformEnum.XBOX;
            await GetRanks(text);
        }

        [Command("ranked eu ps4"), Alias("rank eu ps4", "r eu ps4"), Name("Rank PS4 Europe")]
        [Priority(2)]
        [Summary("Get EU PS4 rank statistics")]
        public async Task GetEUPS4Ranks([Remainder]string text)
        {
            regionEnum = RegionEnum.EMEA;
            platformEnum = PlatformEnum.PS4;
            await GetRanks(text);
        }

        [Command("ranked na"), Alias("rank na", "r na"), Name("Rank America")]
        [Priority(1)]
        [Summary("Get NA rank statistics")]
        public async Task GetNARanks([Remainder]string text)
        {
            regionEnum = RegionEnum.NCSA;
            await GetRanks(text);
        }

        [Command("ranked na pc"), Alias("rank na pc", "r na pc"), Name("Rank PC America")]
        [Priority(2)]
        [Summary("Get NA PC rank statistics")]
        public async Task GetNAPCRanks([Remainder]string text)
        {
            regionEnum = RegionEnum.NCSA;
            platformEnum = PlatformEnum.PC;
            await GetRanks(text);
        }

        [Command("ranked na xbox"), Alias("rank na xbox", "r na xbox"), Name("Rank XBOX America")]
        [Priority(2)]
        [Summary("Get NA XBOX rank statistics")]
        public async Task GetNAXBOXRanks([Remainder]string text)
        {
            regionEnum = RegionEnum.NCSA;
            platformEnum = PlatformEnum.XBOX;
            await GetRanks(text);
        }

        [Command("ranked na ps4"), Alias("rank na ps4", "r na ps4"), Name("Rank PS4 America")]
        [Priority(2)]
        [Summary("Get NA PS4 rank statistics")]
        public async Task GetNAPS4Ranks([Remainder]string text)
        {
            regionEnum = RegionEnum.NCSA;
            platformEnum = PlatformEnum.PS4;
            await GetRanks(text);
        }

        [Command("ranked asia"), Alias("rank asia", "r asia"), Name("Rank asia")]
        [Priority(1)]
        [Summary("Get ASIA rank statistics")]
        public async Task GetASIARanks([Remainder]string text)
        {
            regionEnum = RegionEnum.APAC;
            await GetRanks(text);
        }

        [Command("ranked asia pc"), Alias("rank asia pc", "r asia pc"), Name("Rank PC ASIA")]
        [Priority(2)]
        [Summary("Get ASIA PC rank statistics")]
        public async Task GetASIAPCRanks([Remainder]string text)
        {
            regionEnum = RegionEnum.EMEA;
            platformEnum = PlatformEnum.PC;
            await GetRanks(text);
        }

        [Command("ranked asia xbox"), Alias("rank asia xbox", "r asia xbox"), Name("Rank XBOX ASIA")]
        [Priority(2)]
        [Summary("Get ASIA XBOX rank statistics")]
        public async Task GetASIAXBOXRanks([Remainder]string text)
        {
            regionEnum = RegionEnum.EMEA;
            platformEnum = PlatformEnum.XBOX;
            await GetRanks(text);
        }

        [Command("ranked asia ps4"), Alias("rank asia ps4", "r asia ps4"), Name("Rank PS4 ASIA")]
        [Priority(2)]
        [Summary("Get ASIA PS4 rank statistics")]
        public async Task GetASIAPS4Ranks([Remainder]string text)
        {
            regionEnum = RegionEnum.EMEA;
            platformEnum = PlatformEnum.PS4;
            await GetRanks(text);
        }

        [Command("ranked"), Alias("rank", "r"), Name("Rank Default Region")]
        [Priority(0)]
        [Summary("Get Default Region Rank Statistics")]
        public async Task GetRanks([Remainder]string text)
        {
            var model = await PlayerService.GetPlayerInfoFromR6DB(text, baseUrl, xAppId);
            if (model?.guessed != null && model.guessed.IsGuessed)
            {
                await ReplyAsync($"We found **{model.guessed.PlayersFound}** likely results for the name **{text}** if the following stats are not the once you are looking for, please be more specific with the name/region/platform.");
            }

            var regionInfo = new RegionInfoModel();
            switch (regionEnum)
            {
                case RegionEnum.EMEA:
                    regionInfo.SetEURegionInfo(model);
                    break;
                case RegionEnum.APAC:
                    regionInfo.SetASIARegionInfo(model);
                    break;
                case RegionEnum.NCSA:
                    regionInfo.SetNARegionInfo(model);
                    break;
            }
            await SendRankedInformationMessage(model, regionInfo);
        }

        private async Task SendRankedInformationMessage(PlayerModel model, RegionInfoModel regionInfo)
        {
            var rankNr = 0;
            var builder = new EmbedBuilder();

            var region = regionEnum.GetAttribute<RegionInformation>().Description;            
            var platform = platformEnum.GetAttribute<PlatformInformation>().Description;

            builder.AddField("General Information", "**Level:** " + model?.level);
            
            if (regionInfo != null)
            {
                builder.AddInlineField(region + " Current Season",  "**Rank:** " + StringVisualiser.ToReadableRank(regionInfo.rank) + Environment.NewLine +
                                                                    "**MMR:** " + regionInfo.mmr.ToString("#.##") + Environment.NewLine +
                                                                    "**Highest MMR:** " + regionInfo.max_mmr.ToString("#.##") + Environment.NewLine +
                                                                    "**Next Rank:** " + StringVisualiser.CeilingRankMMR(regionInfo.rank) + Environment.NewLine +
                                                                    "**W/L/A:** " + regionInfo.wins + "/" + regionInfo.losses + "/" + regionInfo.abandons + Environment.NewLine +
                                                                    "**W/L Ratio:** **" + StringVisualiser.GetRatio(regionInfo.wins, regionInfo.losses) + "**");

                if (rankNr < regionInfo.rank)
                {
                    rankNr = regionInfo.rank;
                }
            }

            if(model?.stats?.ranked != null)
            {
                TimeSpan timePlayed = TimeSpan.FromSeconds((double)model?.stats?.ranked?.timePlayed);

                builder.AddInlineField(region + " All Time","**Total Matches Played: ** " + model?.stats?.ranked?.played + Environment.NewLine +
                                                            "**Total W/L (Ratio):** " + model?.stats?.ranked?.won + " / " + model?.stats?.ranked?.lost + " **(" + StringVisualiser.GetRatio(model?.stats?.ranked?.won, model?.stats?.ranked?.lost) + ")**" + Environment.NewLine +
                                                            "**Total K/D (Ratio):** " + model?.stats?.ranked?.kills + " / " + model?.stats?.ranked?.deaths + " **(" + StringVisualiser.GetRatio(model?.stats?.ranked?.kills, model?.stats?.ranked?.deaths) + ")**");
            }

            if (model?.lastPlayed != null)
            {
                TimeSpan rankSeconds = TimeSpan.FromSeconds((double)model?.lastPlayed?.ranked);
                    
                builder.AddInlineField("**Play Time**", StringVisualiser.ToReadablePlaytime(rankSeconds));
                builder.AddInlineField("**Last Played**", model?.lastPlayed?.last_played?.ToString("dd MMMM yyyy hh:mm:ss") ?? "Too long ago");
            }


            builder.Author = new EmbedAuthorBuilder
            {
                IconUrl = "https://i.redd.it/iznunq2m8vgy.png",
                Name = platform + " " + region + " Ranked Information",
                Url = "http://r6db.com/player/" + model.id
            };

            builder.Footer = new EmbedFooterBuilder
            {
                IconUrl = "https://i.redd.it/iznunq2m8vgy.png",
                Text = "Created by Dakpan#6955"
            };

            builder.ThumbnailUrl = StringVisualiser.GetRankImage(rankNr);
            builder.ImageUrl = "http://r6db.com/player/" + model?.id;
            builder.Description = region + " Ranked information on " + platform + " for **" + model?.name + "**";
            builder.Timestamp = DateTime.UtcNow;
            builder.Url = "http://r6db.com/player/" + model?.id;

            builder.WithColor(Color.Orange);

            await ReplyAsync(string.Empty, false, builder);
        }
    }
}
