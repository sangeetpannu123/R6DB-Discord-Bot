using Discord;
using Discord.Commands;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using R6DB_Bot.Models;
using R6DB_Bot.Extensions;
using R6DB_Bot.Enums;
using R6DB_Bot.Services;

namespace R6DB_Bot.Modules
{
    [Name("Casual Information")]
    public class CasualModule : ModuleBase<SocketCommandContext>
    {
        public string baseUrl = "";
        public string xAppId = "";

        private readonly CommandService _service;
        private readonly IConfigurationRoot _config;
        private static string Prefix = "!";

        private RegionEnum regionEnum;
        private PlatformEnum platformEnum;

        public CasualModule(CommandService service, IConfigurationRoot config)
        {
            _service = service;
            _config = config;

            baseUrl = _config["r6db_url"];
            xAppId = _config["x-app-id"];

            regionEnum = RegionEnum.EMEA;
            platformEnum = PlatformEnum.PC;
        }

        [Command("casual eu"), Alias("c eu"), Name("Casual Europe")]
        [Priority(1)]
        [Summary("Get Casual statistics")]
        public async Task GetEUCasuals([Remainder]string text)
        {
            regionEnum = RegionEnum.EMEA;
            await GetCasual(text);
        }

        [Command("casual eu pc"), Alias("c eu pc"), Name("Casual PC Europe")]
        [Priority(2)]
        [Summary("Get EU PC Casual statistics")]
        public async Task GetEUPCCasual([Remainder]string text)
        {
            regionEnum = RegionEnum.EMEA;
            platformEnum = PlatformEnum.PC;
            await GetCasual(text);
        }

        [Command("casual eu xbox"), Alias("c eu xbox"), Name("Casual XBOX Europe")]
        [Priority(2)]
        [Summary("Get EU XBOX Casual statistics")]
        public async Task GetEUXBOXCasual([Remainder]string text)
        {
            regionEnum = RegionEnum.EMEA;
            platformEnum = PlatformEnum.XBOX;
            await GetCasual(text);
        }

        [Command("casual eu ps4"), Alias("c eu ps4"), Name("Casual PS4 Europe")]
        [Priority(2)]
        [Summary("Get EU PS4 Casual statistics")]
        public async Task GetEUPS4Casual([Remainder]string text)
        {
            regionEnum = RegionEnum.EMEA;
            platformEnum = PlatformEnum.PS4;
            await GetCasual(text);
        }

        [Command("casual na"), Alias("c na"), Name("Casual America")]
        [Priority(1)]
        [Summary("Get NA Casual statistics")]
        public async Task GetNACasual([Remainder]string text)
        {
            regionEnum = RegionEnum.NCSA;
            await GetCasual(text);
        }

        [Command("casual na pc"), Alias("c na pc"), Name("Casual PC America")]
        [Priority(2)]
        [Summary("Get NA PC Casual statistics")]
        public async Task GetNAPCCasual([Remainder]string text)
        {
            regionEnum = RegionEnum.NCSA;
            platformEnum = PlatformEnum.PC;
            await GetCasual(text);
        }

        [Command("casual na xbox"), Alias("c na xbox"), Name("Casual XBOX America")]
        [Priority(2)]
        [Summary("Get NA XBOX Casual statistics")]
        public async Task GetNAXBOXCasual([Remainder]string text)
        {
            regionEnum = RegionEnum.NCSA;
            platformEnum = PlatformEnum.XBOX;
            await GetCasual(text);
        }

        [Command("casual na ps4"), Alias("c na ps4"), Name("Casual PS4 America")]
        [Priority(2)]
        [Summary("Get NA PS4 Casual statistics")]
        public async Task GetNAPS4Casual([Remainder]string text)
        {
            regionEnum = RegionEnum.NCSA;
            platformEnum = PlatformEnum.PS4;
            await GetCasual(text);
        }

        [Command("casual asia"), Alias("c asia"), Name("Casual asia")]
        [Priority(1)]
        [Summary("Get ASIA Casual statistics")]
        public async Task GetASIACasual([Remainder]string text)
        {
            regionEnum = RegionEnum.APAC;
            await GetCasual(text);
        }

        [Command("casual asia pc"), Alias("c asia pc"), Name("Casual PC ASIA")]
        [Priority(2)]
        [Summary("Get ASIA PC Casual statistics")]
        public async Task GetASIAPCCasual([Remainder]string text)
        {
            regionEnum = RegionEnum.EMEA;
            platformEnum = PlatformEnum.PC;
            await GetCasual(text);
        }

        [Command("casual asia xbox"), Alias("c asia xbox"), Name("Casual XBOX ASIA")]
        [Priority(2)]
        [Summary("Get ASIA XBOX Casual statistics")]
        public async Task GetASIAXBOXCasual([Remainder]string text)
        {
            regionEnum = RegionEnum.EMEA;
            platformEnum = PlatformEnum.XBOX;
            await GetCasual(text);
        }

        [Command("casual asia ps4"), Alias("c asia ps4"), Name("Casual PS4 ASIA")]
        [Priority(2)]
        [Summary("Get ASIA PS4 Casual statistics")]
        public async Task GetASIAPS4Casual([Remainder]string text)
        {
            regionEnum = RegionEnum.EMEA;
            platformEnum = PlatformEnum.PS4;
            await GetCasual(text);
        }

        [Command("casual"), Alias("c"), Name("Casual Default Region")]
        [Priority(0)]
        [Summary("Get Default Region Casual Statistics")]
        public async Task GetCasual([Remainder]string text)
        {
            try
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
                await SendCasualInformationMessage(model, regionInfo);


            }
            catch (Exception ex)
            {

                if (ex.Message.Contains("Failed to fetch") || ex.Message.Contains("BadGateway"))
                {
                    await ReplyAsync($"R6DB is down, we will be back shortly, if this takes more than 24 hours send a message to Dakpan#6955");
                    return;
                }

                await ReplyAsync($"Something went wrong, I send a message to the developers they will look into it, please try again later!");


                var builder = new EmbedBuilder();
                builder.AddField("Message", text);


                //Exception Message splitting
                var exceptionMessage = ex.Message;
                var exceptionMessageLength = exceptionMessage.Length;
                var nr_of_exceptionMessages = (exceptionMessage.Length / 1000) + 1;

                if (nr_of_exceptionMessages == 1)
                {
                    builder.AddField("Exception Message", exceptionMessage);
                }
                else
                {
                    for (var i = 0; i < nr_of_exceptionMessages; i++)
                    {
                        builder.AddField("Exception Message Nr " + (i + 1), exceptionMessage.Substring(0, 1000));
                    }
                }


                //Stacktrace splitting
                var stackTrace = ex.StackTrace;
                var stackTraceLength = stackTrace.Length;
                var nr_of_stacktraces = (stackTrace.Length / 1000) + 1;

                if (nr_of_stacktraces == 1)
                {
                    builder.AddField("Exception Stacktrace", stackTrace);
                }
                else
                {
                    for (var i = 0; i < nr_of_stacktraces; i++)
                    {
                        builder.AddField("Exception Stacktrace Nr " + (i + 1), stackTrace.Substring(0, 1000));
                    }
                }


                builder.Author = new EmbedAuthorBuilder
                {
                    IconUrl = "https://i.redd.it/iznunq2m8vgy.png",
                    Name = "Error Caught",
                    //Url = "http://r6db.com/player/" + model.id
                };

                builder.Footer = new EmbedFooterBuilder
                {
                    IconUrl = "https://i.redd.it/iznunq2m8vgy.png",
                    Text = "Created by Dakpan#6955"
                };

                //builder.ThumbnailUrl = StringVisualiser.GetRankImage(rankNr);
                //builder.ImageUrl = "http://r6db.com/player/" + model?.id;
                builder.Timestamp = DateTime.UtcNow;
                //builder.Url = "http://r6db.com/player/" + model?.id;

                builder.WithColor(Color.Red);

                var u = Context.Guild.GetUser(132556381046833152);
                await u.SendMessageAsync(string.Empty, false, builder);
            }

        }

        private async Task SendCasualInformationMessage(PlayerModel model, RegionInfoModel regionInfo)
        {
            var builder = new EmbedBuilder();

            var region = regionEnum.GetAttribute<RegionInformation>().Description;            
            var platform = platformEnum.GetAttribute<PlatformInformation>().Description;

            builder.AddField("General Information", "**Level:** " + model?.level);

            if(model?.stats?.casual != null)
            {
                TimeSpan timePlayed = TimeSpan.FromSeconds((double)model?.stats?.casual?.timePlayed);

                builder.AddInlineField(region + " All Time","**Total Matches Played: ** " + model?.stats?.casual?.played + Environment.NewLine +
                                                            "**Total W/L (Ratio):** " + model?.stats?.casual?.won + " / " + model?.stats?.casual?.lost + " **(" + StringVisualiser.GetRatio(model?.stats?.casual?.won, model?.stats?.casual?.lost) + ")**" + Environment.NewLine +
                                                            "**Total K/D (Ratio):** " + model?.stats?.casual?.kills + " / " + model?.stats?.casual?.deaths + " **(" + StringVisualiser.GetRatio(model?.stats?.casual?.kills, model?.stats?.casual?.deaths) + ")**");
            }

            if (model?.lastPlayed != null)
            {
                TimeSpan casualSeconds = TimeSpan.FromSeconds((double)model?.lastPlayed?.casual);
                    
                builder.AddInlineField("**Play Time**", StringVisualiser.ToReadablePlaytime(casualSeconds));
                builder.AddInlineField("**Last Played**", model?.lastPlayed?.last_played?.ToString("dd MMMM yyyy hh:mm:ss"));
            }

            builder.ImageUrl = "https://ubistatic-a.akamaihd.net/0058/prod/assets/images/season5-casual20.f31680a7.svg";
            builder.Description = region + " Casual information on " + platform + " for **" + model?.name + "**";

            builder.Author = new EmbedAuthorBuilder
            {
                IconUrl = "https://i.redd.it/iznunq2m8vgy.png",
                Name = platform + " " + region + " Casual Information",
                Url = "http://r6db.com/player/" + model?.id
            };

            builder.Footer = new EmbedFooterBuilder
            {
                IconUrl = "https://i.redd.it/iznunq2m8vgy.png",
                Text = "Created by Dakpan#6955"
            };

            builder.ThumbnailUrl = "https://uplay-avatars.s3.amazonaws.com/" + model?.id + "/default_146_146.png";
            builder.Timestamp = DateTime.UtcNow;
            builder.Url = "http://r6db.com/player/" + model?.id;

            builder.WithColor(Color.Orange);

            await ReplyAsync(string.Empty, false, builder);
        }
    }
}
