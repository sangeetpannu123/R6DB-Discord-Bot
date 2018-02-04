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
    [Name("Operator Information")]
    public class OperatorModule : ModuleBase<SocketCommandContext>
    {
        public string baseUrl = "";
        public string xAppId = "";

        private readonly CommandService _service;
        private readonly IConfigurationRoot _config;
        private static string Prefix = "!";

        private RegionEnum regionEnum;
        private PlatformEnum platformEnum;
        private OperatorEnum operatorEnum;

        public OperatorModule(CommandService service, IConfigurationRoot config)
        {
            _service = service;
            _config = config;

            baseUrl = _config["r6db_url"];
            xAppId = _config["x-app-id"];
            
            platformEnum = PlatformEnum.PC;
            regionEnum = RegionEnum.EMEA;
            operatorEnum = OperatorEnum.THERMITE;
        }

        [Command("operator pc"), Alias("op pc"), Name("Operator PC")]
        [Priority(1)]
        [Summary("Get operator information about the player")]
        public async Task GetOperatorIQ([Remainder]string text)
        {
            platformEnum = PlatformEnum.PC;
            await GetOperator(text);
        }

        [Command("operator xbox"), Alias("op xbox"), Name("Operator XBOX")]
        [Priority(1)]
        [Summary("Get operator information about the player")]
        public async Task GetXBOXProfile([Remainder]string text)
        {
            platformEnum = PlatformEnum.XBOX;
            await GetOperator(text);
        }

        [Command("operator ps4"), Alias("op ps4"), Name("Operator PS4")]
        [Priority(1)]
        [Summary("Get operator information about the player")]
        public async Task GetPS4Profile([Remainder]string text)
        {
            platformEnum = PlatformEnum.PS4;
            await GetOperator(text);
        }

        [Command("operator"), Alias("op"), Name("Operator")]
        [Priority(0)]
        [Summary("Get operator information about the player")]
        public async Task GetOperator([Remainder]string text)
        {
            try
            {                
                var textArray       = text.Split(" ");
                var operatorText    = textArray[0].ToUpper();
                var playerNameText  = textArray[1];
            
                try
                {
                    operatorEnum = (OperatorEnum)Enum.Parse(typeof(OperatorEnum), operatorText);
                }
    #pragma warning disable CS0168 // Variable is declared but never used
                catch (Exception ex)
    #pragma warning restore CS0168 // Variable is declared but never used
                {
                    //var operatorArray = (OperatorEnum[])Enum.GetValues(typeof(OperatorEnum));
                    await ReplyAsync($"No operator found with the name **{operatorText}**.");
                }

                var model = await PlayerService.GetPlayerInfoFromR6DB(playerNameText, baseUrl, xAppId);
                if (model?.guessed != null && model.guessed.IsGuessed)
                {
                    await ReplyAsync($"We found **{model.guessed.PlayersFound}** likely results for the name **{text}** if the following stats are not the once you are looking for, please be more specific with the name/region/platform.");
                }

                var operatorModel = new OperatorInfoModel();
                switch(operatorEnum)
                {
                    case OperatorEnum.ASH:
                        operatorModel.kills         = model?.stats?.Operator?.ash?.kills;
                        operatorModel.deaths        = model?.stats?.Operator?.ash?.deaths;
                        operatorModel.won           = model?.stats?.Operator?.ash?.won;
                        operatorModel.lost          = model?.stats?.Operator?.ash?.lost;
                        operatorModel.timePlayed    = model?.stats?.Operator?.ash?.timePlayed;
                        operatorModel.name          = model?.stats?.Operator?.ash?.name;
                        break;
                    case OperatorEnum.BANDIT:
                        operatorModel.kills = model?.stats?.Operator?.bandit?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.bandit?.deaths;
                        operatorModel.won = model?.stats?.Operator?.bandit?.won;
                        operatorModel.lost = model?.stats?.Operator?.bandit?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.bandit?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.bandit?.name;
                        break;
                    case OperatorEnum.BLACKBEARD:
                        operatorModel.kills = model?.stats?.Operator?.blackbeard?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.blackbeard?.deaths;
                        operatorModel.won = model?.stats?.Operator?.blackbeard?.won;
                        operatorModel.lost = model?.stats?.Operator?.blackbeard?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.blackbeard?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.blackbeard?.name;
                        break;
                    case OperatorEnum.BLITZ:
                        operatorModel.kills = model?.stats?.Operator?.blitz?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.blitz?.deaths;
                        operatorModel.won = model?.stats?.Operator?.blitz?.won;
                        operatorModel.lost = model?.stats?.Operator?.blitz?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.blitz?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.blitz?.name;
                        break;
                    case OperatorEnum.BUCK:
                        operatorModel.kills = model?.stats?.Operator?.buck?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.buck?.deaths;
                        operatorModel.won = model?.stats?.Operator?.buck?.won;
                        operatorModel.lost = model?.stats?.Operator?.buck?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.buck?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.buck?.name;
                        break;
                    case OperatorEnum.CAPITAO:
                        operatorModel.kills = model?.stats?.Operator?.capitao?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.capitao?.deaths;
                        operatorModel.won = model?.stats?.Operator?.capitao?.won;
                        operatorModel.lost = model?.stats?.Operator?.capitao?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.capitao?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.capitao?.name;
                        break;
                    case OperatorEnum.CASTLE:
                        operatorModel.kills = model?.stats?.Operator?.castle?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.castle?.deaths;
                        operatorModel.won = model?.stats?.Operator?.castle?.won;
                        operatorModel.lost = model?.stats?.Operator?.castle?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.castle?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.castle?.name;
                        break;
                    case OperatorEnum.CAVEIRA:
                        operatorModel.kills = model?.stats?.Operator?.caveira?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.caveira?.deaths;
                        operatorModel.won = model?.stats?.Operator?.caveira?.won;
                        operatorModel.lost = model?.stats?.Operator?.caveira?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.caveira?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.caveira?.name;
                        break;
                    case OperatorEnum.DOC:
                        operatorModel.kills = model?.stats?.Operator?.doc?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.doc?.deaths;
                        operatorModel.won = model?.stats?.Operator?.doc?.won;
                        operatorModel.lost = model?.stats?.Operator?.doc?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.doc?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.doc?.name;
                        break;
                    case OperatorEnum.DOKKAEBI:
                        operatorModel.kills = model?.stats?.Operator?.dokkaebi?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.dokkaebi?.deaths;
                        operatorModel.won = model?.stats?.Operator?.dokkaebi?.won;
                        operatorModel.lost = model?.stats?.Operator?.dokkaebi?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.dokkaebi?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.dokkaebi?.name;
                        break;
                    case OperatorEnum.ECHO:
                        operatorModel.kills = model?.stats?.Operator?.echo?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.echo?.deaths;
                        operatorModel.won = model?.stats?.Operator?.echo?.won;
                        operatorModel.lost = model?.stats?.Operator?.echo?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.echo?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.echo?.name;
                        break;
                    case OperatorEnum.ELA:
                        operatorModel.kills = model?.stats?.Operator?.ela?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.ela?.deaths;
                        operatorModel.won = model?.stats?.Operator?.ela?.won;
                        operatorModel.lost = model?.stats?.Operator?.ela?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.ela?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.ela?.name;
                        break;
                    case OperatorEnum.FROST:
                        operatorModel.kills = model?.stats?.Operator?.frost?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.frost?.deaths;
                        operatorModel.won = model?.stats?.Operator?.frost?.won;
                        operatorModel.lost = model?.stats?.Operator?.frost?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.frost?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.frost?.name;
                        break;
                    case OperatorEnum.FUZE:
                        operatorModel.kills = model?.stats?.Operator?.fuze?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.fuze?.deaths;
                        operatorModel.won = model?.stats?.Operator?.fuze?.won;
                        operatorModel.lost = model?.stats?.Operator?.fuze?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.fuze?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.fuze?.name;
                        break;
                    case OperatorEnum.GLAZ:
                        operatorModel.kills = model?.stats?.Operator?.glaz?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.glaz?.deaths;
                        operatorModel.won = model?.stats?.Operator?.glaz?.won;
                        operatorModel.lost = model?.stats?.Operator?.glaz?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.glaz?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.glaz?.name;
                        break;
                    case OperatorEnum.HIBANA:
                        operatorModel.kills = model?.stats?.Operator?.hibana?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.hibana?.deaths;
                        operatorModel.won = model?.stats?.Operator?.hibana?.won;
                        operatorModel.lost = model?.stats?.Operator?.hibana?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.hibana?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.hibana?.name;
                        break;
                    case OperatorEnum.IQ:
                        operatorModel.kills = model?.stats?.Operator?.iq?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.iq?.deaths;
                        operatorModel.won = model?.stats?.Operator?.iq?.won;
                        operatorModel.lost = model?.stats?.Operator?.iq?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.iq?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.iq?.name;
                        break;
                    case OperatorEnum.JACKAL:
                        operatorModel.kills = model?.stats?.Operator?.jackal?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.jackal?.deaths;
                        operatorModel.won = model?.stats?.Operator?.jackal?.won;
                        operatorModel.lost = model?.stats?.Operator?.jackal?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.jackal?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.jackal?.name;
                        break;
                    case OperatorEnum.JAGER:
                        operatorModel.kills = model?.stats?.Operator?.jager?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.jager?.deaths;
                        operatorModel.won = model?.stats?.Operator?.jager?.won;
                        operatorModel.lost = model?.stats?.Operator?.jager?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.jager?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.jager?.name;
                        break;
                    case OperatorEnum.KAPKAN:
                        operatorModel.kills = model?.stats?.Operator?.kapkan?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.kapkan?.deaths;
                        operatorModel.won = model?.stats?.Operator?.kapkan?.won;
                        operatorModel.lost = model?.stats?.Operator?.kapkan?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.kapkan?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.kapkan?.name;
                        break;
                    case OperatorEnum.LESION:
                        operatorModel.kills = model?.stats?.Operator?.lesion?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.lesion?.deaths;
                        operatorModel.won = model?.stats?.Operator?.lesion?.won;
                        operatorModel.lost = model?.stats?.Operator?.lesion?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.lesion?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.lesion?.name;
                        break;
                    case OperatorEnum.MIRA:
                        operatorModel.kills = model?.stats?.Operator?.mira?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.mira?.deaths;
                        operatorModel.won = model?.stats?.Operator?.mira?.won;
                        operatorModel.lost = model?.stats?.Operator?.mira?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.mira?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.mira?.name;
                        break;
                    case OperatorEnum.MONTAGNE:
                        operatorModel.kills = model?.stats?.Operator?.montagne?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.montagne?.deaths;
                        operatorModel.won = model?.stats?.Operator?.montagne?.won;
                        operatorModel.lost = model?.stats?.Operator?.montagne?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.montagne?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.montagne?.name;
                        break;
                    case OperatorEnum.MUTE:
                        operatorModel.kills = model?.stats?.Operator?.mute?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.mute?.deaths;
                        operatorModel.won = model?.stats?.Operator?.mute?.won;
                        operatorModel.lost = model?.stats?.Operator?.mute?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.mute?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.mute?.name;
                        break;
                    case OperatorEnum.PULSE:
                        operatorModel.kills = model?.stats?.Operator?.pulse?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.pulse?.deaths;
                        operatorModel.won = model?.stats?.Operator?.pulse?.won;
                        operatorModel.lost = model?.stats?.Operator?.pulse?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.pulse?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.pulse?.name;
                        break;
                    case OperatorEnum.RECRUIT1:
                        operatorModel.kills = model?.stats?.Operator?.recruit1?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.recruit1?.deaths;
                        operatorModel.won = model?.stats?.Operator?.recruit1?.won;
                        operatorModel.lost = model?.stats?.Operator?.recruit1?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.recruit1?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.recruit1?.name;
                        break;
                    case OperatorEnum.RECRUIT2:
                        operatorModel.kills = model?.stats?.Operator?.recruit2?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.recruit2?.deaths;
                        operatorModel.won = model?.stats?.Operator?.recruit2?.won;
                        operatorModel.lost = model?.stats?.Operator?.recruit2?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.recruit2?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.recruit2?.name;
                        break;
                    case OperatorEnum.RECRUIT3:
                        operatorModel.kills = model?.stats?.Operator?.recruit3?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.recruit3?.deaths;
                        operatorModel.won = model?.stats?.Operator?.recruit3?.won;
                        operatorModel.lost = model?.stats?.Operator?.recruit3?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.recruit3?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.recruit3?.name;
                        break;
                    case OperatorEnum.RECRUIT4:
                        operatorModel.kills = model?.stats?.Operator?.recruit4?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.recruit4?.deaths;
                        operatorModel.won = model?.stats?.Operator?.recruit4?.won;
                        operatorModel.lost = model?.stats?.Operator?.recruit4?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.recruit4?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.recruit4?.name;
                        break;
                    case OperatorEnum.RECRUIT5:
                        operatorModel.kills = model?.stats?.Operator?.recruit5?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.recruit5?.deaths;
                        operatorModel.won = model?.stats?.Operator?.recruit5?.won;
                        operatorModel.lost = model?.stats?.Operator?.recruit5?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.recruit5?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.recruit5?.name;
                        break;
                    case OperatorEnum.ROOK:
                        operatorModel.kills = model?.stats?.Operator?.rook?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.rook?.deaths;
                        operatorModel.won = model?.stats?.Operator?.rook?.won;
                        operatorModel.lost = model?.stats?.Operator?.rook?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.rook?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.rook?.name;
                        break;
                    case OperatorEnum.SLEDGE:
                        operatorModel.kills = model?.stats?.Operator?.sledge?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.sledge?.deaths;
                        operatorModel.won = model?.stats?.Operator?.sledge?.won;
                        operatorModel.lost = model?.stats?.Operator?.sledge?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.sledge?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.sledge?.name;
                        break;
                    case OperatorEnum.SMOKE:
                        operatorModel.kills = model?.stats?.Operator?.smoke?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.smoke?.deaths;
                        operatorModel.won = model?.stats?.Operator?.smoke?.won;
                        operatorModel.lost = model?.stats?.Operator?.smoke?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.smoke?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.smoke?.name;
                        break;
                    case OperatorEnum.TACHANKA:
                        operatorModel.kills = model?.stats?.Operator?.tachanka?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.tachanka?.deaths;
                        operatorModel.won = model?.stats?.Operator?.tachanka?.won;
                        operatorModel.lost = model?.stats?.Operator?.tachanka?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.tachanka?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.tachanka?.name;
                        break;
                    case OperatorEnum.THATCHER:
                        operatorModel.kills = model?.stats?.Operator?.thatcher?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.thatcher?.deaths;
                        operatorModel.won = model?.stats?.Operator?.thatcher?.won;
                        operatorModel.lost = model?.stats?.Operator?.thatcher?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.thatcher?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.thatcher?.name;
                        break;
                    case OperatorEnum.THERMITE:
                        operatorModel.kills = model?.stats?.Operator?.thermite?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.thermite?.deaths;
                        operatorModel.won = model?.stats?.Operator?.thermite?.won;
                        operatorModel.lost = model?.stats?.Operator?.thermite?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.thermite?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.thermite?.name;
                        break;
                    case OperatorEnum.TWITCH:
                        operatorModel.kills = model?.stats?.Operator?.twitch?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.twitch?.deaths;
                        operatorModel.won = model?.stats?.Operator?.twitch?.won;
                        operatorModel.lost = model?.stats?.Operator?.twitch?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.twitch?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.twitch?.name;
                        break;
                    case OperatorEnum.VALKYRIE:
                        operatorModel.kills = model?.stats?.Operator?.valkyrie?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.valkyrie?.deaths;
                        operatorModel.won = model?.stats?.Operator?.valkyrie?.won;
                        operatorModel.lost = model?.stats?.Operator?.valkyrie?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.valkyrie?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.valkyrie?.name;
                        break;
                    case OperatorEnum.VIGIL:
                        operatorModel.kills = model?.stats?.Operator?.vigil?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.vigil?.deaths;
                        operatorModel.won = model?.stats?.Operator?.vigil?.won;
                        operatorModel.lost = model?.stats?.Operator?.vigil?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.vigil?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.vigil?.name;
                        break;
                    case OperatorEnum.YING:
                        operatorModel.kills = model?.stats?.Operator?.ying?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.ying?.deaths;
                        operatorModel.won = model?.stats?.Operator?.ying?.won;
                        operatorModel.lost = model?.stats?.Operator?.ying?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.ying?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.ying?.name;
                        break;
                    case OperatorEnum.ZOFIA:
                        operatorModel.kills = model?.stats?.Operator?.zofia?.kills;
                        operatorModel.deaths = model?.stats?.Operator?.zofia?.deaths;
                        operatorModel.won = model?.stats?.Operator?.zofia?.won;
                        operatorModel.lost = model?.stats?.Operator?.zofia?.lost;
                        operatorModel.timePlayed = model?.stats?.Operator?.zofia?.timePlayed;
                        operatorModel.name = model?.stats?.Operator?.zofia?.name;
                        break;
                }

                await SendOperatorInformationMessage(model, operatorModel);


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

        private async Task SendOperatorInformationMessage(PlayerModel model, OperatorInfoModel operatorModel)
        {
            var builder = new EmbedBuilder();

            var region = regionEnum.GetAttribute<RegionInformation>().Description;            
            var platform = platformEnum.GetAttribute<PlatformInformation>().Description;
            var operatorURL = operatorEnum.GetAttribute<OperatorInformation>().URL;
            
            builder.AddInlineField("Win Loss", "**Win:** " + operatorModel.won + "  **Loss:** " + operatorModel.lost + Environment.NewLine +
                                                "**Ratio: " + StringVisualiser.GetRatio(operatorModel.won, operatorModel.lost) + "**");

            builder.AddInlineField("Kill Death", "**Kill:** " + operatorModel.kills + "  **Death:** " + operatorModel.deaths + Environment.NewLine +
                                                "**Ratio: " + StringVisualiser.GetRatio(operatorModel.kills, operatorModel.deaths) + "**");
            
            TimeSpan operatorTimePlayed = TimeSpan.FromSeconds((double)operatorModel.timePlayed);
            builder.AddField("Time Played", StringVisualiser.ToReadablePlaytime(operatorTimePlayed));

            builder.Description = $"**{operatorModel.name}** Operator information for player **{model?.name}** in **{region}** on **{platform}**";

            builder.Author = new EmbedAuthorBuilder
            {
                IconUrl = "https://i.redd.it/iznunq2m8vgy.png",
                Name = platform + " " + region + " Player Operator",
                Url = "http://r6db.com/player/" + model?.id
            };

            builder.Footer = new EmbedFooterBuilder
            {
                IconUrl = "https://i.redd.it/iznunq2m8vgy.png",
                Text = "Created by Dakpan#6955"
            };

            builder.ThumbnailUrl = operatorURL;
            builder.Timestamp = DateTime.UtcNow;
            builder.Url = "http://r6db.com/player/" + model?.id;

            builder.WithColor(Color.Orange);

            await ReplyAsync(string.Empty, false, builder);
        }
    }
}
