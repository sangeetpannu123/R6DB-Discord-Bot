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
    [Name("Profile Information")]
    public class ProfileModule : ModuleBase<SocketCommandContext>
    {
        public string baseUrl = "";
        public string xAppId = "";

        private readonly CommandService _service;
        private readonly IConfigurationRoot _config;
        private static string Prefix = "!";

        private RegionEnum regionEnum;
        private PlatformEnum platformEnum;

        public ProfileModule(CommandService service, IConfigurationRoot config)
        {
            _service = service;
            _config = config;

            baseUrl = _config["r6db_url"];
            xAppId = _config["x-app-id"];
            
            platformEnum = PlatformEnum.PC;
        }

        [Command("profile pc"), Alias("p pc"), Name("Profile PC")]
        [Priority(1)]
        [Summary("Get profile information about the player")]
        public async Task GetPCProfile([Remainder]string text)
        {
            platformEnum = PlatformEnum.PC;
            await GetPlayerProfile(text);
        }

        [Command("profile xbox"), Alias("p xbox"), Name("Profile XBOX")]
        [Priority(1)]
        [Summary("Get profile information about the player")]
        public async Task GetXBOXProfile([Remainder]string text)
        {
            platformEnum = PlatformEnum.XBOX;
            await GetPlayerProfile(text);
        }

        [Command("profile ps4"), Alias("p ps4"), Name("Profile PS4")]
        [Priority(1)]
        [Summary("Get profile information about the player")]
        public async Task GetPS4Profile([Remainder]string text)
        {
            platformEnum = PlatformEnum.PS4;
            await GetPlayerProfile(text);
        }

        [Command("profile"), Alias("p"), Name("Profile")]
        [Priority(0)]
        [Summary("Get profile information about the player")]
        public async Task GetPlayerProfile([Remainder]string text)
        {
            try
            { 
                var model = await PlayerService.GetPlayerInfoFromR6DB(text, baseUrl, xAppId);
                if (model?.guessed != null && model.guessed.IsGuessed)
                {
                    await ReplyAsync($"We found **{model.guessed.PlayersFound}** likely results for the name **{text}** if the following stats are not the once you are looking for, please be more specific with the name/region/platform.");
                }

                await SendPlayerInformationMessage(model);

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

        private async Task SendPlayerInformationMessage(PlayerModel model)
        {
            var builder = new EmbedBuilder();

            var region = regionEnum.GetAttribute<RegionInformation>().Description;            
            var platform = platformEnum.GetAttribute<PlatformInformation>().Description;

            var placementInfo = "";
            if(model?.placements != null)
            {
                placementInfo = Environment.NewLine  +
                                "**Global Rank:** "  + model?.placements?.global ?? " not placed " + Environment.NewLine +
                                "**Europe Rank:** "  + model?.placements?.emea ?? " not placed " + Environment.NewLine +
                                "**America Rank:** " + model?.placements?.ncsa ?? " not placed " + Environment.NewLine +
                                "**Asia Rank:** "    + model?.placements?.apac ?? " not placed " + Environment.NewLine;
            }

            builder.AddField("General Information", "**Level:** " + model?.level + placementInfo);


            builder.AddField("Technical Information", "**ID:** " + model?.id + Environment.NewLine +
                                                      "**UserID:** " + model?.userId ?? "Unknown" + Environment.NewLine +
                                                      "**Profile Added:** " + model?.created_at?.ToString("dd MMMM yyyy hh:mm:ss") + Environment.NewLine +
                                                      "**Last Played:** " + model?.lastPlayed?.last_played?.ToString("dd MMMM yyyy hh:mm:ss") + Environment.NewLine);           

            if(model?.aliases != null)
            {
                var aliases = "";
                foreach(var alias in model?.aliases)
                {
                    aliases += alias.name + Environment.NewLine  + "    `" + alias.created_at?.ToString("dd MMMM yyyy hh:mm:ss") + "`" + Environment.NewLine + Environment.NewLine;
                }
                builder.AddField("Aliases", aliases);
            }

            builder.Description = region + " Player Profile information on " + platform + " for **" + model?.name + "**";

            builder.Author = new EmbedAuthorBuilder
            {
                IconUrl = "https://i.redd.it/iznunq2m8vgy.png",
                Name = platform + " " + region + " Player Profile",
                Url = "http://r6db.com/player/" + model?.id
            };

            builder.Footer = new EmbedFooterBuilder
            {
                IconUrl = "https://i.redd.it/iznunq2m8vgy.png",
                Text = "Created by Dakpan#6955"
            };

            builder.ThumbnailUrl = "https://uplay-avatars.s3.amazonaws.com/" + model?.id + "/default_146_146.png";
            builder.ImageUrl = "http://r6db.com/player/" + model?.id;
            builder.Timestamp = DateTime.UtcNow;
            builder.Url = "http://r6db.com/player/" + model?.id;

            builder.WithColor(Color.Orange);

            await ReplyAsync(string.Empty, false, builder);
        }
    }
}
