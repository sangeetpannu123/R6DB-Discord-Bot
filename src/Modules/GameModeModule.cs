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
    [Name("Game Mode Information")]
    public class GameModeModule : ModuleBase<SocketCommandContext>
    {
        public string baseUrl = "";
        public string xAppId = "";

        private readonly CommandService _service;
        private readonly IConfigurationRoot _config;
        private static string Prefix = "!";

        private RegionEnum regionEnum;
        private PlatformEnum platformEnum;

        public GameModeModule(CommandService service, IConfigurationRoot config)
        {
            _service = service;
            _config = config;

            baseUrl = _config["r6db_url"];
            xAppId = _config["x-app-id"];

            regionEnum = RegionEnum.EMEA;
            platformEnum = PlatformEnum.PC;
        }

        [Command("gamemode eu"), Alias("gamemode eu", "r eu"), Name("Game Mode Europe")]
        [Priority(1)]
        [Summary("Get game mode statistics")]
        public async Task GetEUGameModes([Remainder]string text)
        {
            regionEnum = RegionEnum.EMEA;
            await GetGameModes(text);
        }

        [Command("gamemode eu pc"), Alias("gamemode eu pc", "r eu pc"), Name("Game Mode PC Europe")]
        [Priority(2)]
        [Summary("Get EU PC game mode statistics")]
        public async Task GetEUPCGameModes([Remainder]string text)
        {
            regionEnum = RegionEnum.EMEA;
            platformEnum = PlatformEnum.PC;
            await GetGameModes(text);
        }

        [Command("gamemode eu xbox"), Alias("gamemode eu xbox", "r eu xbox"), Name("Game Mode XBOX Europe")]
        [Priority(2)]
        [Summary("Get EU XBOX game mode statistics")]
        public async Task GetEUXBOXGameModes([Remainder]string text)
        {
            regionEnum = RegionEnum.EMEA;
            platformEnum = PlatformEnum.XBOX;
            await GetGameModes(text);
        }

        [Command("gamemode eu ps4"), Alias("gamemode eu ps4", "r eu ps4"), Name("Game Mode PS4 Europe")]
        [Priority(2)]
        [Summary("Get EU PS4 game mode statistics")]
        public async Task GetEUPS4GameModes([Remainder]string text)
        {
            regionEnum = RegionEnum.EMEA;
            platformEnum = PlatformEnum.PS4;
            await GetGameModes(text);
        }

        [Command("gamemode na"), Alias("gamemode na", "r na"), Name("Game Mode America")]
        [Priority(1)]
        [Summary("Get NA game mode statistics")]
        public async Task GetNAGameModes([Remainder]string text)
        {
            regionEnum = RegionEnum.NCSA;
            await GetGameModes(text);
        }

        [Command("gamemode na pc"), Alias("gamemode na pc", "r na pc"), Name("Game Mode PC America")]
        [Priority(2)]
        [Summary("Get NA PC game mode statistics")]
        public async Task GetNAPCGameModes([Remainder]string text)
        {
            regionEnum = RegionEnum.NCSA;
            platformEnum = PlatformEnum.PC;
            await GetGameModes(text);
        }

        [Command("gamemode na xbox"), Alias("gamemode na xbox", "r na xbox"), Name("Game Mode XBOX America")]
        [Priority(2)]
        [Summary("Get NA XBOX game mode statistics")]
        public async Task GetNAXBOXGameModes([Remainder]string text)
        {
            regionEnum = RegionEnum.NCSA;
            platformEnum = PlatformEnum.XBOX;
            await GetGameModes(text);
        }

        [Command("gamemode na ps4"), Alias("gamemode na ps4", "r na ps4"), Name("Game Mode PS4 America")]
        [Priority(2)]
        [Summary("Get NA PS4 game mode statistics")]
        public async Task GetNAPS4GameModes([Remainder]string text)
        {
            regionEnum = RegionEnum.NCSA;
            platformEnum = PlatformEnum.PS4;
            await GetGameModes(text);
        }

        [Command("gamemode asia"), Alias("gamemode asia", "r asia"), Name("Game Mode asia")]
        [Priority(1)]
        [Summary("Get ASIA game mode statistics")]
        public async Task GetASIAGameModes([Remainder]string text)
        {
            regionEnum = RegionEnum.APAC;
            await GetGameModes(text);
        }

        [Command("gamemode asia pc"), Alias("gamemode asia pc", "r asia pc"), Name("Game Mode PC ASIA")]
        [Priority(2)]
        [Summary("Get ASIA PC game mode statistics")]
        public async Task GetASIAPCGameModes([Remainder]string text)
        {
            regionEnum = RegionEnum.EMEA;
            platformEnum = PlatformEnum.PC;
            await GetGameModes(text);
        }

        [Command("gamemode asia xbox"), Alias("gamemode asia xbox", "r asia xbox"), Name("Game Mode XBOX ASIA")]
        [Priority(2)]
        [Summary("Get ASIA XBOX game mode statistics")]
        public async Task GetASIAXBOXGameModes([Remainder]string text)
        {
            regionEnum = RegionEnum.EMEA;
            platformEnum = PlatformEnum.XBOX;
            await GetGameModes(text);
        }

        [Command("gamemode asia ps4"), Alias("gamemode asia ps4", "r asia ps4"), Name("Game Mode PS4 ASIA")]
        [Priority(2)]
        [Summary("Get ASIA PS4 game mode statistics")]
        public async Task GetASIAPS4GameModes([Remainder]string text)
        {
            regionEnum = RegionEnum.EMEA;
            platformEnum = PlatformEnum.PS4;
            await GetGameModes(text);
        }

        [Command("gamemode"), Alias("gamemode", "r"), Name("Game Mode Default Region")]
        [Priority(0)]
        [Summary("Get Default Region Game Mode Statistics")]
        public async Task GetGameModes([Remainder]string text)
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
                await SendGameModeInformationMessage(model, regionInfo);
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

        private async Task SendGameModeInformationMessage(PlayerModel model, RegionInfoModel regionInfo)
        {
            var builder = new EmbedBuilder();

            var region = regionEnum.GetAttribute<RegionInformation>().Description;            
            var platform = platformEnum.GetAttribute<PlatformInformation>().Description;
            

            if (model?.stats != null)
            {
                if(model?.stats?.bomb != null)
                {
                    builder.AddField("**Bomb**",  $"**Win:** {model?.stats?.bomb?.won}" + Environment.NewLine +
                                                  $"**Lost:** {model?.stats?.bomb?.lost}" + Environment.NewLine +
                                                  $"**Played:** {model?.stats?.bomb?.played}" + Environment.NewLine +
                                                  $"**Ratio:** {StringVisualiser.GetRatio(model?.stats?.bomb?.won, model?.stats?.bomb?.lost)}" + Environment.NewLine +
                                                  $"**Best Score:** {model?.stats?.bomb?.bestScore}" + Environment.NewLine);
                }

                if (model?.stats?.secure != null)
                {
                    builder.AddField("**Secure**",  $"**Win:** {model?.stats?.secure?.won}" + Environment.NewLine +
                                                    $"**Lost:** {model?.stats?.secure?.lost}" + Environment.NewLine +
                                                    $"**Played:** {model?.stats?.secure?.played}" + Environment.NewLine +
                                                    $"**Ratio:** {StringVisualiser.GetRatio(model?.stats?.secure?.won, model?.stats?.secure?.lost)}" + Environment.NewLine +
                                                    $"**Best Score:** {model?.stats?.secure?.bestScore}" + Environment.NewLine);
                }

                if (model?.stats?.hostage != null)
                {
                    builder.AddField("**Hostage**",     $"**Win:** {model?.stats?.hostage?.won}" + Environment.NewLine +
                                                        $"**Lost:** {model?.stats?.hostage?.lost}" + Environment.NewLine +
                                                        $"**Played:** {model?.stats?.hostage?.played}" + Environment.NewLine +
                                                        $"**Ratio:** {StringVisualiser.GetRatio(model?.stats?.hostage?.won, model?.stats?.hostage?.lost)}" + Environment.NewLine +
                                                        $"**Best Score:** {model?.stats?.hostage?.bestScore}" + Environment.NewLine);
                }
            }
            
            builder.Description = region + " Game Mode information on " + platform + " for **" + model?.name + "**";

            builder.Author = new EmbedAuthorBuilder
            {
                IconUrl = "https://i.redd.it/iznunq2m8vgy.png",
                Name = platform + " " + region + " Game Mode Information",
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
