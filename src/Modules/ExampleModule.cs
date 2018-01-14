﻿using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace R6DB_Bot.Modules
{
    [Name("Example")]
    public class ExampleModule : ModuleBase<SocketCommandContext>
    {
        private readonly CommandService _service;
        private readonly IConfigurationRoot _config;
        private static string Prefix = "!";

        public ExampleModule(CommandService service, IConfigurationRoot config)
        {
            _service = service;
            _config = config;
        }

        [Command("e"), Alias("e"), Name("Example")]
        [Summary("Get you rank")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public void Example([Remainder]string text)
        {

            ReplyAsync($"you said **{text}**");
        }

        //[Group("rank"), Alias("r"), Name("Rank")]
        //[RequireContext(ContextType.Guild)]
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
