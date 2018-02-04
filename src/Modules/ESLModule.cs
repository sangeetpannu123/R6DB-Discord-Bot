using Discord;
using Discord.Commands;
using HtmlAgilityPack;
using Microsoft.Extensions.Configuration;
using R6DB_Bot.Enums;
using R6DB_Bot.Extensions;
using R6DB_Bot.Models;
using R6DB_Bot.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Reflection;

namespace R6DB_Bot.Modules
{
    [Name("ESL")]
    public class ESLModule : ModuleBase<SocketCommandContext>
    {
        private readonly CommandService _service;
        private readonly IConfigurationRoot _config;
        private static string Prefix = "!";

        public string baseUrl = "";
        public string xAppId = "";

        private RegionEnum regionEnum;
        private PlatformEnum platformEnum;

        public ESLModule(CommandService service, IConfigurationRoot config)
        {
            _service = service;
            _config = config;

            baseUrl = _config["r6db_url"];
            xAppId = _config["x-app-id"];

            regionEnum = RegionEnum.EMEA;
            platformEnum = PlatformEnum.PC;
        }

        [Command("esl match"), Alias("em"), Name("esl")]
        [Summary("Get information about ESL matches")]
        public async Task GetESLMatchAsync([Remainder]string text)
        {
            if (!text.Contains("play.eslgaming"))
            {
                await ReplyAsync("Please provide a valid ESL match URL");
                return;
            }

            await ReplyAsync("I am gathering all the data for this match, brb!");

            var model = GetESLMatchInfoByURL(text);

            await SendMatchMessage(model);

            foreach (var team in model.Teams)
            {
                GetESLTeamPlayersByURL(team);

                await SendTeamMessage(team);

                foreach(var player in team.Players)
                {
                    await SendPlayerMessage(player);
                }
            }
        }

        private async Task SendMatchMessage(ESLMatchModel model)
        {
            var builder = new EmbedBuilder();

            builder.AddField("Match Information", $"Found a match; **" + model.MatchName + "**");

            foreach (var team in model.Teams)
            {
                builder.AddInlineField("Team Info Team", team.TeamName);
            }

            builder.Description = "Match Found";

            builder.Author = new EmbedAuthorBuilder
            {
                IconUrl = "https://i.redd.it/iznunq2m8vgy.png",
                Name = "ESL Match INFO",
                //Url = "http://r6db.com/player/" + model?.id
            };

            builder.Footer = new EmbedFooterBuilder
            {
                IconUrl = "https://i.redd.it/iznunq2m8vgy.png",
                Text = "Created by Dakpan#6955"
            };
            builder.Timestamp = DateTime.UtcNow;

            /* builder.ThumbnailUrl = "https://uplay-avatars.s3.amazonaws.com/" + model?.id + "/default_146_146.png";
             builder.ImageUrl = "http://r6db.com/player/" + model?.id;
             builder.Url = "http://r6db.com/player/" + model?.id;*/

            builder.WithColor(Color.Orange);

            await ReplyAsync(string.Empty, false, builder);
        }

        private ESLMatchModel GetESLMatchInfoByURL(string text)
        {
            var model = new ESLMatchModel
            {
                MatchURL = text,
                MatchID = GetIDFromURL(text)
            };
            model.Teams = new List<ESLTeamModel>();

            var pageUrl = $"https://play.eslgaming.com/match/{model.MatchID}/";
            // Call the page and get the generated HTML
            var doc = new HtmlAgilityPack.HtmlDocument();
            HtmlAgilityPack.HtmlNode.ElementsFlags["br"] = HtmlAgilityPack.HtmlElementFlag.Empty;
            doc.OptionWriteEmptyNodes = true;

            try
            {
                var webRequest = WebRequest.Create(pageUrl);
                Stream stream = webRequest.GetResponse().GetResponseStream();
                doc.Load(stream);
                stream.Close();
            }
            catch (System.UriFormatException uex)
            {
                //Log.Fatal("There was an error in the format of the url: " + pageUrl, uex);
                throw;
            }
            catch (System.Net.WebException wex)
            {
                //Log.Fatal("There was an error connecting to the url: " + pageUrl, wex);
                throw;
            }

            var ESL_baseUrl = "https://play.eslgaming.com";

            var team1 = new ESLTeamModel();

            //get the div by id and then get the inner text
            var team1_td = doc.DocumentNode.SelectSingleNode("//div[@class='esl-content']/table/tr[3]/td/table/tr/td");
            var team1_a = doc.DocumentNode.SelectSingleNode("//div[@class='esl-content']/table/tr[3]/td/table/tr/td/a");
            var team1_url = ESL_baseUrl + team1_a.Attributes["href"].Value;
            var team1_name = Regex.Replace(team1_td.InnerText, @"\n", string.Empty);
            team1_name = team1_name.TrimEnd().TrimStart();

            team1.TeamName = team1_name;
            team1.TeamURL = team1_url;

            model.Teams.Add(team1);

            var team2 = new ESLTeamModel();

            var team2_td = doc.DocumentNode.SelectSingleNode("//div[@class='esl-content']/table/tr[3]/td/table/tr/td[last()]");
            var team2_a = doc.DocumentNode.SelectSingleNode("//div[@class='esl-content']/table/tr[3]/td/table/tr/td[last()]/a");
            var team2_url = ESL_baseUrl + team2_a.Attributes["href"].Value;
            var team2_name = Regex.Replace(team2_td.InnerText, @"\n", string.Empty);
            team2_name = team2_name.TrimEnd().TrimStart();

            team2.TeamName = team2_name;
            team2.TeamURL = team2_url;

            model.Teams.Add(team2);

            return model;
        }

        [Command("esl team"), Alias("et"), Name("esl team")]
        [Summary("Get information about ESL Team")]
        public async Task GetESLTeamAsync([Remainder]string text)
        {
            if(!text.Contains("play.eslgaming"))
            {
                await ReplyAsync("Please provide a valid ESL team URL");
                return;
            }

            await ReplyAsync("I am searching through all of the ESL website for the team, this might take a little bit, brb!");

            var ESLTeam = new ESLTeamModel
            {
                TeamURL = text
            };

            GetESLTeamPlayersByURL(ESLTeam);

            await SendTeamMessage(ESLTeam);

            foreach(var player in ESLTeam.Players)
            {
                await SendPlayerMessage(player);
            }
        }

        private async Task SendTeamMessage(ESLTeamModel model)
        {
            if (string.IsNullOrEmpty(model.TeamID))
            {
                GetESLTeamPlayersByURL(model);
            }

            var builder = new EmbedBuilder();

            builder.AddField("Team Information", $"We found a team with these (uPlay) player names ; **" + model.Players.Select(c => c.PlayerName).JoinWith(Environment.NewLine) + "**");

            builder.Description = "Match Found";

            builder.Author = new EmbedAuthorBuilder
            {
                IconUrl = "https://i.redd.it/iznunq2m8vgy.png",
                Name = "ESL Match INFO",
                //Url = "http://r6db.com/player/" + model?.id
            };

            builder.Footer = new EmbedFooterBuilder
            {
                IconUrl = "https://i.redd.it/iznunq2m8vgy.png",
                Text = "Created by Dakpan#6955"
            };
            builder.Timestamp = DateTime.UtcNow;

            /* builder.ThumbnailUrl = "https://uplay-avatars.s3.amazonaws.com/" + model?.id + "/default_146_146.png";
             builder.ImageUrl = "http://r6db.com/player/" + model?.id;
             builder.Url = "http://r6db.com/player/" + model?.id;*/

            builder.WithColor(Color.Orange);

            await ReplyAsync(string.Empty, false, builder);
        }

        private string GetESLPlayerByURL(string text)
        {
            var player_id = GetIDFromURL(text);
            var uplay_name = GetUplayName(player_id);
            return uplay_name;
        }

        [Command("esl player"), Alias("ep"), Name("esl player")]
        [Summary("Get information about a ESL player")]
        public async Task GetESLPlayerAsync([Remainder]string text)
        {
            if (!text.Contains("play.eslgaming"))
            {
                await ReplyAsync("Please provide a valid ESL player URL");
                return;
            }

            await ReplyAsync("I am gathering all the data for this player, brb!");

            var ESLPlayer = new ESLPlayerModel
            {
                PlayerURL = text
            };

            await SendPlayerMessage(ESLPlayer);
        }

        private async Task SendPlayerMessage(ESLPlayerModel ESLModel)
        {
            if (string.IsNullOrEmpty(ESLModel.PlayerName))
            {
                ESLModel.PlayerName = GetESLPlayerByURL(ESLModel.PlayerURL);
            }

            var model = await PlayerService.GetPlayerInfoFromR6DB(ESLModel.PlayerName, baseUrl, xAppId);
            var builder = new EmbedBuilder();

            var regionInfo = new RegionInfoModel();
            regionInfo.SetHighestRegion(model);

            if (model?.stats != null)
            {
                var informationString = "";

                if (regionInfo != null)
                {
                    informationString += "Rank: **" + StringVisualiser.ToReadableRank(regionInfo.rank) + "**" + Environment.NewLine +
                                         "MMR: **" + regionInfo.mmr.ToString("#.##") + "**" + Environment.NewLine +
                                         "W/L Ratio: **" + StringVisualiser.GetRatio(regionInfo.wins, regionInfo.losses) + "**" + Environment.NewLine;
                }

                if (model?.stats?.bomb != null)
                {
                    informationString += $"Bomb Win Ratio: **{StringVisualiser.GetRatio(model?.stats?.bomb?.won, model?.stats?.bomb?.lost)}**" + Environment.NewLine;
                }

                builder.AddField("**ESL Player Information**", informationString);

                var defendOperatorInformation = "";
                var attackOperatorInformation = "";
                if (model?.stats?.Operator != null)
                {
                    var attack_operators = model?.stats?.Operator.GetAllAttackOperators();
                    attack_operators = attack_operators.OrderByDescending(m => m.timePlayed).ToList();

                    for (var i = 0; i < 3; i++)
                    {
                        var op = attack_operators[i];

                        TimeSpan operatorTimePlayed = TimeSpan.FromSeconds((double)op.timePlayed);
                        attackOperatorInformation += "**Operator:** " + op.name + Environment.NewLine +
                                                       "**W/L Ratio:** " + StringVisualiser.GetRatio(op.won, op.lost) + Environment.NewLine +
                                                       "**K/D Ratio:** " + StringVisualiser.GetRatio(op.kills, op.deaths) + Environment.NewLine +
                                                       "**Play Time:** " + StringVisualiser.ToReadablePlaytimeHours(operatorTimePlayed) + Environment.NewLine + Environment.NewLine;
                    }

                    builder.AddInlineField("**Most Played** ***ATK*** **Operator**", attackOperatorInformation);


                    var defend_operators = model?.stats?.Operator.GetAllDefendOperators();
                    defend_operators = defend_operators.OrderByDescending(m => m.timePlayed).ToList();

                    for (var i = 0; i < 3; i++)
                    {
                        var op = defend_operators[i];

                        TimeSpan operatorTimePlayed = TimeSpan.FromSeconds((double)op.timePlayed);
                        defendOperatorInformation += "Operator: **" + op.name + "**" + Environment.NewLine +
                                               "W/L Ratio: **" + StringVisualiser.GetRatio(op.won, op.lost) + "**" + Environment.NewLine +
                                               "K/D Ratio: **" + StringVisualiser.GetRatio(op.kills, op.deaths) + "**" + Environment.NewLine +
                                               "Play Time: **" + StringVisualiser.ToReadablePlaytimeHours(operatorTimePlayed) + "**"
                                               + Environment.NewLine + Environment.NewLine;
                    }
                }

                builder.AddInlineField("**Most Played** ***DEF*** **Operator**", defendOperatorInformation);
            }

            var nameCorrect = model?.name.Trim().ToLower().Equals(ESLModel.PlayerName.Trim().ToLower());
            var nameCorrectText = nameCorrect == true ? "**Correct**" : $"**False** is actual name is **{model?.name}**";

            builder.Description = $"Found a player with the ESL account name **{ESLModel.PlayerName}**. {Environment.NewLine}This name is {nameCorrectText} according to R6DB.";

            builder.Author = new EmbedAuthorBuilder
            {
                IconUrl = "https://i.redd.it/iznunq2m8vgy.png",
                Name = "ESL Player Info",
                Url = "http://r6db.com/player/" + model?.id
            };

            builder.Footer = new EmbedFooterBuilder
            {
                IconUrl = "https://i.redd.it/iznunq2m8vgy.png",
                Text = "Created by Dakpan#6955"
            };
            builder.Timestamp = DateTime.UtcNow;

            builder.ThumbnailUrl = "https://uplay-avatars.s3.amazonaws.com/" + model?.id + "/default_146_146.png";
            builder.ImageUrl = "http://r6db.com/player/" + model?.id;
            builder.Url = "http://r6db.com/player/" + model?.id;

            builder.WithColor(Color.Orange);

            await ReplyAsync(string.Empty, false, builder);
        }

        private void GetESLTeamPlayersByURL(ESLTeamModel model)
        {
            model.TeamID = GetIDFromURL(model.TeamURL);
            GetUplayNamesFromTeamPage(model);
        }

        public string GetIDFromURL(string url)
        {
            var pageUrl = url;
            var splitted_url = pageUrl.Split("/");
            return splitted_url[splitted_url.Length - 2];
        }

        private void GetUplayNamesFromTeamPage(ESLTeamModel model)
        {
            var pageUrl = $"https://play.eslgaming.com/team/members/{model.TeamID}/";

            // Call the page and get the generated HTML
            var doc = new HtmlAgilityPack.HtmlDocument();
            HtmlAgilityPack.HtmlNode.ElementsFlags["br"] = HtmlAgilityPack.HtmlElementFlag.Empty;
            doc.OptionWriteEmptyNodes = true;

            try
            {
                var webRequest = WebRequest.Create(pageUrl);
                Stream stream = webRequest.GetResponse().GetResponseStream();
                doc.Load(stream);
                stream.Close();
            }
            catch (System.UriFormatException uex)
            {
                //Log.Fatal("There was an error in the format of the url: " + pageUrl, uex);
                throw;
            }
            catch (System.Net.WebException wex)
            {
                //Log.Fatal("There was an error connecting to the url: " + pageUrl, wex);
                throw;
            }

            //get the div by id and then get the inner text
            var tables = doc.DocumentNode.SelectNodes("//table//tr//td//table//tr//td//a");

            var players = new List<ESLPlayerModel>();

            foreach(var table in tables)
            {
                var player_url = table.Attributes["href"].Value;
                var player_url_splitted = player_url.Split("/");
                var player_id = player_url_splitted[player_url_splitted.Length - 2];
                players.Add(new ESLPlayerModel
                {
                    PlayerName = GetUplayName(player_id)
                });
            }

            model.Players = players;
        }
        
        private string GetUplayName(string playerID)
        {
            var pageUrl = $"https://play.eslgaming.com/player/gameaccounts/{playerID}/";

            // Call the page and get the generated HTML
            var doc = new HtmlAgilityPack.HtmlDocument();
            HtmlAgilityPack.HtmlNode.ElementsFlags["br"] = HtmlAgilityPack.HtmlElementFlag.Empty;
            doc.OptionWriteEmptyNodes = true;

            try
            {
                var webRequest = WebRequest.Create(pageUrl);
                Stream stream = webRequest.GetResponse().GetResponseStream();
                doc.Load(stream);
                stream.Close();
            }
            catch (System.UriFormatException uex)
            {
                //Log.Fatal("There was an error in the format of the url: " + pageUrl, uex);
                throw;
            }
            catch (System.Net.WebException wex)
            {
                //Log.Fatal("There was an error connecting to the url: " + pageUrl, wex);
                throw;
            }

            //get the div by id and then get the inner text
            var tr_cell = doc.DocumentNode.SelectNodes("//table//tr");
            var uplayName = "";
            
            foreach (HtmlNode row in tr_cell)
            {
                if (row.InnerHtml.Contains("Uplay Nick"))
                {
                    var i = 0;
                    foreach (HtmlNode cell in row.SelectNodes("td"))
                    {
                        if (i == 1)
                        {
                            uplayName = Regex.Replace(cell.InnerText, @"\n|\t", string.Empty).Replace(" ", "");
                        }

                        i++;
                    }
                }
            }

            return uplayName;
        }
    }
}
