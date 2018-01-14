using Discord;
using Discord.Commands;
using Microsoft.Extensions.Configuration;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace R6DB_Bot.Modules
{
    public class RankModule : ModuleBase<SocketCommandContext>
    {
        public string baseUrl = "";
        public string xAppId = "";
        private readonly CommandService _service;
        private readonly IConfigurationRoot _config;

        public RankModule(CommandService service, IConfigurationRoot config)
        {
            _service = service;
            _config = config;

            baseUrl = _config["r6db_url"];
            xAppId = _config["x-app-id"];
        }

        [Command("rank"), Alias("r"), Name("Rank")]
        [Summary("Get you rank")]
        public void Rank([Remainder]string text)
        {
            ReplyAsync($"you said **{text}**");
            
            var requestUri = $"{baseUrl}/Players";

            var queryParams = new List<KeyValuePair<string, string>>();
            queryParams.Add(new KeyValuePair<string, string>("name", "dakpan.kps"));
            queryParams.Add(new KeyValuePair<string, string>("platform", "pc"));

            var response = HttpRequestFactory.Get(requestUri, xAppId);
            Console.WriteLine($"Status: {response.Status}");
            //Console.WriteLine(response.ContentAsString());
            var outputModel = response.Result.ContentAsType<List<Player>>();
            outputModel.ForEach(item => Console.WriteLine("{0}", JsonConvert.SerializeObject(item)));
        }

        //[Group("rank"), Alias("r"), Name("Rank")]
        //public class Set : ModuleBase
        //{
        //    [Command("nick"), Priority(1)]
        //    [Summary("Change your nickname to the specified text")]
        //    [RequireUserPermission(GuildPermission.ChangeNickname)]
        //    public Task Nick([Remainder]string name)
        //        => Nick(Context.User as SocketGuildUser, name);

        //    [Command("nick"), Priority(0)]
        //    [Summary("Change another user's nickname to the specified text")]
        //    [RequireUserPermission(GuildPermission.ManageNicknames)]
        //    public async Task Nick(SocketGuildUser user, [Remainder]string name)
        //    {
        //        await user.ModifyAsync(x => x.Nickname = name);
        //        await ReplyAsync($"{user.Mention} I changed your name to **{name}**");
        //    }
        //}
    }
}
