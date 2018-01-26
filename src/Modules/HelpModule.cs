using Discord;
using Discord.Commands;
using Microsoft.Extensions.Configuration;
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
            
            foreach (var module in _service.Modules)
            {
                string description = null;
                foreach (var cmd in module.Commands)
                {
                    var result = await cmd.CheckPreconditionsAsync(Context);
                    if (result.IsSuccess)
                        description += $"{Prefix}{cmd.Aliases.First()}\n";
                }
                
                if (!string.IsNullOrWhiteSpace(description))
                {
                    builder.AddField(x =>
                    {
                        x.Name = module.Name;
                        x.Value = description;
                        x.IsInline = false;
                    });
                }
            }

            builder.Footer = new EmbedFooterBuilder()
            {
                Text = "Developed By Dakpan Support Server: https://discord.gg/UeBwppF"
            };

            await ReplyAsync("", false, builder.Build());
        }

        [Command("help")]
        public async Task HelpAsync(string command)
        {
            Prefix = _config["prefix"];
            var result = _service.Search(Context, command);

            if (!result.IsSuccess)
            {
                await ReplyAsync($"Sorry, I couldn't find a command like **{command}**.");
                return;
            }

            string prefix = _config["prefix"];
            var builder = new EmbedBuilder()
            {
                Color = new Color(114, 137, 218),
                Description = $"Here are some commands like **{command}**"
            };

            foreach (var match in result.Commands)
            {
                var cmd = match.Command;

                builder.AddField(x =>
                {
                    x.Name = string.Join(", ", cmd.Aliases);
                    x.Value = $"Parameters: {string.Join(", ", cmd.Parameters.Select(p => p.Name))}\n" + 
                              $"Summary: {cmd.Summary}";
                    x.IsInline = false;
                });
            }

            builder.Footer = new EmbedFooterBuilder()
            {
                Text = "Developed By Dakpan Support Server: https://discord.gg/UeBwppF"
            };

            await ReplyAsync("", false, builder.Build());
        }

        [Command("invite"), Alias("i"), Name("invite")]
        [Summary("Get invite link")]
        public async Task InviteAsync()
        {
            await ReplyAsync($"Click on the link to invite me https://discordapp.com/oauth2/authorize?client_id="+_config["client-id"]+"&scope=bot&permissions=19456");
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
            await ReplyAsync($"You can contribute to the project by helping me develop or give me feedback: https://github.com/jeanpoelie/R6DB-Discord-Bot/tree/development!");
        }
    }
}
