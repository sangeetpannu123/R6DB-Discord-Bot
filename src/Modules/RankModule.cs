using Discord.Commands;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace R6DB_Bot.Modules
{
    public class RankModule : ModuleBase<SocketCommandContext>
    {
        public string baseUrl = "";
        public string xAppId = "";

        private readonly CommandService _service;
        private readonly IConfigurationRoot _config;
        private static string Prefix = "!";

        public RankModule(CommandService service, IConfigurationRoot config)
        {
            _service = service;
            _config = config;

            baseUrl = _config["r6db_url"];
            xAppId = _config["x-app-id"];
        }

        [Command("rank"), Alias("r"), Name("Rank")]
        [Summary("Get rank statistics")]
        public async Task HelpAsync([Remainder]string text)
        {
            var requestUri = $"{baseUrl}/Players";
            
            var queryParams = new List<KeyValuePair<string, string>>();
            queryParams.Add(new KeyValuePair<string, string>("name", text));
            queryParams.Add(new KeyValuePair<string, string>("platform", "pc"));
            queryParams.Add(new KeyValuePair<string, string>("exact", "1")); //to make sure the name is exactly this. TODO: change this later into less exact with intelligence for questions like "did you mean.... "

            var response = await HttpRequestFactory.Get(requestUri, xAppId, queryParams);
            var outputModel = response.ContentAsType<List<PlayerModel>>();
            if (outputModel.Count == 0)
            {
                await ReplyAsync($"No player found with the name **{text}**.");
                return;
            }

            outputModel.ForEach(item => ReplyAsync($"We found a player with the name **{item.name}**"));
        }

        //[Command("rank"), Alias("r"), Name("Rank")]
        //[Summary("Get you rank")]
        //public void Rank([Remainder]string text)
        //{
        //    ReplyAsync($"you said **{text}**");

        //    var requestUri = $"{baseUrl}/Players";

        //    var queryParams = new List<KeyValuePair<string, string>>();
        //    queryParams.Add(new KeyValuePair<string, string>("name", "dakpan.kps"));
        //    queryParams.Add(new KeyValuePair<string, string>("platform", "pc"));

        //    var response = HttpRequestFactory.Get(requestUri, xAppId);
        //    Console.WriteLine($"Status: {response.Status}");
        //    //Console.WriteLine(response.ContentAsString());
        //    var outputModel = response.Result.ContentAsType<List<Player>>();
        //    outputModel.ForEach(item => Console.WriteLine("{0}", JsonConvert.SerializeObject(item)));
        //}
    }
}
