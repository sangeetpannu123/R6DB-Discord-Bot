using Discord;
using Discord.Commands;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace R6DB_Bot.Modules
{
    [Name("Help")]
    public class HelpModule : ModuleBase<SocketCommandContext>
    {
        private readonly CommandService _service;
        private readonly IConfigurationRoot _config;
        private static string Prefix = "!";

        public HelpModule(CommandService service, IConfigurationRoot config)
        {
            _service = service;
            _config = config;
        }

        [Command("help")]
        public async Task HelpAsync()
        {
            Prefix = _config["prefix"];
            var builder = new EmbedBuilder()
            {
                Color = new Color(114, 137, 218),
                Description = "These are the commands you can use"
            };

            builder.AddField("Legend", "`[]` = optional " + Environment.NewLine + "`()` = required");

            builder.AddInlineField("R6DB Commands",    $"`{Prefix}casual [region] [platform] (player name)`" + Environment.NewLine +
                                                       $"`{Prefix}profile [region] [platform] (player name)`" + Environment.NewLine +
                                                       $"`{Prefix}operator [region] [platform] (operator name) (player name)`" + Environment.NewLine +
                                                       $"`{Prefix}gamemode [region] [platform] (gamemode) (player name)`" + Environment.NewLine +
                                                       Environment.NewLine +
                                                       $"*Make sure that the following commands are in a spam channel, because they will spam your channel :)*" + Environment.NewLine +
                                                       $"`{Prefix}esl match (ESL MATCH URL)` **beta**" + Environment.NewLine +
                                                       $"`{Prefix}esl team (ESL TEAM URL)` **beta**" + Environment.NewLine +
                                                       $"`{Prefix}esl player (ESL PLAYER URL)` **beta**");

            builder.AddInlineField("Example", $"{Prefix}casual eu pc dakpan" + Environment.NewLine +
                                              $"{Prefix}profile eu pc dakpan" + Environment.NewLine +
                                              $"{Prefix}operator eu pc fuze dakpan" + Environment.NewLine +
                                              $"{Prefix}gamemode eu pc hostage dakpan" + Environment.NewLine +
                                              $"{Prefix}esl match https://play.eslgaming.com/rainbowsix/europe-pc/r6siege/major/go4r6-europe/cup-81/match/35281332/" + Environment.NewLine +
                                              $"{Prefix}esl team https://play.eslgaming.com/team/11450266/" + Environment.NewLine +
                                              $"{Prefix}esl player https://play.eslgaming.com/player/9798223/");


            builder.AddField("Bot Commands",   $"`{Prefix}invite`" + Environment.NewLine +
                                                $"`{Prefix}support`" + Environment.NewLine +
                                                $"`{Prefix}contribute`" + Environment.NewLine +
                                                $"`{Prefix}todo`" + Environment.NewLine +
                                                $"`{Prefix}guild`" + Environment.NewLine +
                                                $"`{Prefix}bug (What you did to get the bug)`" + Environment.NewLine +
                                                $"`{Prefix}feedback (Feedback text)`");


            //foreach (var module in _service.Modules)
            //{
            //    string description = null;
            //    foreach (var cmd in module.Commands)
            //    {
            //        var result = await cmd.CheckPreconditionsAsync(Context);
            //        if (result.IsSuccess)
            //            description += $"{Prefix}{cmd.Aliases.First()}\n";
            //    }

            //    if (!string.IsNullOrWhiteSpace(description))
            //    {
            //        builder.AddField(x =>
            //        {
            //            x.Name = module.Name;
            //            x.Value = description + " " + module.Aliases + " " + module.Attributes + " " + module.Commands + " " + module.IsSubmodule + " " + module.Parent + " " + module.Preconditions + " " + module.Remarks + " " + module.Service + " " + module.Submodules + " " + module.Summary;
            //            x.IsInline = false;
            //        });
            //    }
            //}

            builder.Footer = new EmbedFooterBuilder()
            {
                Text = "Developed By Dakpan#6955"
            };

            await ReplyAsync("", false, builder.Build());
        }

        //[Command("help")]
        //public async Task HelpAsync(string command)
        //{
        //    Prefix = _config["prefix"];
        //    var result = _service.Search(Context, command);

        //    if (!result.IsSuccess)
        //    {
        //        await ReplyAsync($"Sorry, I couldn't find a command like **{command}**.");
        //        return;
        //    }

        //    string prefix = _config["prefix"];
        //    var builder = new EmbedBuilder()
        //    {
        //        Color = new Color(114, 137, 218),
        //        Description = $"Here are some commands like **{command}**"
        //    };

        //    foreach (var match in result.Commands)
        //    {
        //        var cmd = match.Command;

        //        builder.AddField(x =>
        //        {
        //            x.Name = string.Join(", ", cmd.Aliases);
        //            x.Value = $"Parameters: {string.Join(", ", cmd.Parameters.Select(p => p.Name))}\n" + 
        //                      $"Summary: {cmd.Summary}";
        //            x.IsInline = false;
        //        });
        //    }

        //    builder.Footer = new EmbedFooterBuilder()
        //    {
        //        Text = "Developed By Dakpan Support Server: https://discord.gg/UeBwppF"
        //    };

        //    await ReplyAsync("", false, builder.Build());
        //}

        [Command("invite"), Alias("i"), Name("invite")]
        [Summary("Get invite link")]
        public async Task InviteAsync()
        {
            await ReplyAsync($"Click on the link to invite me https://discordapp.com/oauth2/authorize?client_id={_config["client-id"]}scope=bot&permissions=19456");
        }

        [Command("support"), Alias("s"), Name("support")]
        [Summary("How to support me")]
        public async Task SupportAsync()
        {
            await ReplyAsync($"You can support me by buying some beers for me using the following link: https://www.paypal.me/Dakpan or by helping me develop the bot!");
        }

        [Command("contribute"), Name("contribute")]
        [Summary("How to contribute to the project")]
        public async Task ContributeAsync()
        {
            await ReplyAsync($"You can contribute to the project by helping me develop or give me feedback: https://github.com/jeanpoelie/R6DB-Discord-Bot/tree/development");
        }

        [Command("todo"), Name("todo")]
        [Summary("You can find the todo list here!")]
        public async Task TODOAsync()
        {
            await ReplyAsync($"You can see the stuff I still want to do & bug fixes here: https://github.com/jeanpoelie/R6DB-Discord-Bot/projects/1");
        }

        [Command("guild"), Alias("g"), Name("guild")]
        [Summary("Get the number of active Guilds")]
        public async Task GuildAsync()
        {
            await ReplyAsync($"The bot is current active in {Context.Client.Guilds.Count} servers.");
        }

        [Command("feedback"), Alias("fb"), Name("feedback")]
        [Summary("Send feedback to developers")]
        public async Task SendFeedback([Remainder]string text)
        {
            var builder = new EmbedBuilder();

            builder.AddField("Message", text);

            builder.Author = new EmbedAuthorBuilder
            {
                Name = "Feedback from " + Context.Message.Author
            };

            builder.WithColor(Color.Green);

            var u = Context.Guild.GetUser(132556381046833152);
            await u.SendMessageAsync(string.Empty, false, builder);

            await ReplyAsync($"Thank you submitting your feedback!");
        }

        [Command("bug"), Name("bug")]
        [Summary("Send bug to developers")]
        public async Task SendBug([Remainder]string text)
        {
            var builder = new EmbedBuilder();

            builder.AddField("Message", text);

            builder.Author = new EmbedAuthorBuilder
            {
                Name = "Bug notification from " + Context.Message.Author
            };

            builder.WithColor(Color.Green);

            var u = Context.Guild.GetUser(132556381046833152);
            await u.SendMessageAsync(string.Empty, false, builder);

            await ReplyAsync($"Thank you submitting your bug, we appreciate this very much because we know how time consuming and annoying bugs are, We will look into this ASAP!");
        }
    }
}
