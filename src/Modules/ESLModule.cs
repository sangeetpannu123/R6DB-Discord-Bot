using Discord;
using Discord.Commands;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace R6DB_Bot.Modules
{
    [Name("ESL")]
    public class ESLModule : ModuleBase<SocketCommandContext>
    {
        private readonly CommandService _service;
        private readonly IConfigurationRoot _config;
        private static string Prefix = "!";

        public ESLModule(CommandService service, IConfigurationRoot config)
        {
            _service = service;
            _config = config;
        }

        [Command("esl match"), Alias("em"), Name("esl")]
        [Summary("Get information about ESL matches")]
        public async Task GetESLMatchAsync()
        {
            var pageUrl = "https://play.eslgaming.com/rainbowsix/europe-pc/r6siege/major/go4r6-italy/cup-17/match/35655337/";
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

            var baseUrl = "https://play.eslgaming.com";
            //get the div by id and then get the inner text
            var team1_td = doc.DocumentNode.SelectSingleNode("//div[@class='esl-content']/table/tr[3]/td/table/tr/td");
            var team1_a = doc.DocumentNode.SelectSingleNode("//div[@class='esl-content']/table/tr[3]/td/table/tr/td/a");
            var team1_url = baseUrl+team1_a.Attributes["href"].Value;
            var team1_name = Regex.Replace(team1_td.InnerText, @"\n", string.Empty);
            team1_name = team1_name.TrimEnd().TrimStart();

            var team2_td = doc.DocumentNode.SelectSingleNode("//div[@class='esl-content']/table/tr[3]/td/table/tr/td[last()]");
            var team2_a = doc.DocumentNode.SelectSingleNode("//div[@class='esl-content']/table/tr[3]/td/table/tr/td[last()]/a");
            var team2_url = baseUrl+team2_a.Attributes["href"].Value;
            var team2_name = Regex.Replace(team2_td.InnerText, @"\n", string.Empty);
            team2_name = team2_name.TrimEnd().TrimStart();


            await SendESLMatchMessage(team1_name, team2_name);
        }

        private async Task SendESLMatchMessage(string team1_name, string team2_name)
        {
            var builder = new EmbedBuilder();

            var placementInfo = "";
            
            builder.AddField("Match Information", $"Found a match; /n **" + team1_name + "** vs. **" + team2_name + "**");
            

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
    }
}
