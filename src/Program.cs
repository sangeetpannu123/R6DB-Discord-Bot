﻿using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace R6DB_Bot
{
    public class Program
    {
        private DiscordSocketClient _discordClient;

        private static string Prefix = "!";

        public static void Main(string[] args)
            => new Program().StartAsync().GetAwaiter().GetResult();

        private IConfigurationRoot _config;

        public async Task StartAsync()
        {
            var builder = new ConfigurationBuilder()    // Begin building the configuration file
                .SetBasePath(AppContext.BaseDirectory)  // Specify the location of the config
                .AddJsonFile("_configuration.json");    // Add the configuration file
            _config = builder.Build();                  // Build the configuration file

            Prefix = _config["prefix"];

            var services = new ServiceCollection()      // Begin building the service provider
                .AddSingleton(new DiscordSocketClient(new DiscordSocketConfig     // Add the discord client to the service provider
                {
                    LogLevel = LogSeverity.Verbose,
                    MessageCacheSize = 1000     // Tell Discord.Net to cache 1000 messages per channel
                }))
                .AddSingleton(new CommandService(new CommandServiceConfig     // Add the command service to the service provider
                {
                    DefaultRunMode = RunMode.Async,     // Force all commands to run async
                    LogLevel = LogSeverity.Verbose
                }))
                .AddSingleton<CommandHandler>()     // Add remaining services to the provider
                .AddSingleton<LoggingService>()     
                .AddSingleton<StartupService>()
                .AddSingleton<Random>()             // You get better random with a single instance than by creating a new one every time you need it
                .AddSingleton(_config);

            var provider = services.BuildServiceProvider();     // Create the service provider

            provider.GetRequiredService<LoggingService>();      // Initialize the logging service, startup service, and command handler
            await provider.GetRequiredService<StartupService>().StartAsync();
            provider.GetRequiredService<CommandHandler>();

            _discordClient = provider.GetService<DiscordSocketClient>();
            _discordClient.MessageReceived += OnMessageReceivedAsync;
            //_discordClient.JoinedGuild += _client_JoinedGuild;

            await Task.Delay(-1);     // Prevent the application from closing
        }

        public async Task OnMessageReceivedAsync(SocketMessage parameterMessage)
        {
            if (!(parameterMessage is SocketUserMessage message)) return;
            var argPos = 0;
            var context = new SocketCommandContext(_discordClient, message); //new CommandContext(_client, message);

            if (context.User.IsBot)
                return;

            if (!(message.HasMentionPrefix(_discordClient.CurrentUser, ref argPos) ||
                  message.HasStringPrefix(Prefix, ref argPos))) return;

            // var result = await _commands.ExecuteAsync(context, argPos, Provider);

            // var commandsuccess = result.IsSuccess;


            //if (true)
            //{
            //    var embed = new EmbedBuilder();

            //    foreach (var module in _commands.Modules)
            //        foreach (var command in module.Commands)
            //            if (context.Message.Content.ToLower()
            //                .StartsWith($"{Config.Load().Prefix}{command.Name} ".ToLower()))
            //            {
            //                embed.AddField("COMMAND INFO", $"Name: `{Prefix}{command.Summary}`\n" +
            //                                               $"Info: {command.Remarks}");
            //                break;
            //            }

            //    /*embed.AddField($"ERROR {result.Error.ToString().ToUpper()}", $"__Command:__ \n{context.Message}\n" +
            //                                                                 $"__Error:__ \n**{result.ErrorReason}**\n\n" +
            //                                                                 $"To report this error, please type: `{Config.Load().Prefix}BugReport <errormessage>`");*/

            //    embed.Color = Color.Red;
            //    await context.Channel.SendMessageAsync("", false, embed.Build());
            //    await Logger.In3Error(context.Message.Content, context.Guild.Name, context.Channel.Name, context.User.Username);
            //}
            //else
            //{
            //    await Logger.In3(context.Message.Content, context.Guild.Name, context.Channel.Name, context.User.Username);
            //    Commands++;
            //}

            //if (Commands % 50 == 0)
            //{
            //    var backupfile = Path.Combine(AppContext.BaseDirectory,
            //        $"setup\\backups/{DateTime.UtcNow:dd-MM-yy HH.mm.ss}.txt");
            //    File.WriteAllText(backupfile, File.ReadAllText(ServerList.EloFile));
            //}
        }

        private static async Task _client_JoinedGuild(SocketGuild guild)
        {
            var embed = new EmbedBuilder();
            embed.AddField("R6DB Bot ",
                $"Beep boop, R6DB Bot here! Type `{Prefix}help` to see a list of my commands.");
            embed.WithColor(Color.Blue);
            embed.AddField("Developed By Dakpan", "Support Server: https://discord.gg/UeBwppF");
            try
            {
                await guild.DefaultChannel.SendMessageAsync("", false, embed.Build());
            }
            catch
            {
                //
            }
        }


        private static void client_AskedInviteLink()
        {
            var embed = new EmbedBuilder();
            embed.AddField("R6DB Bot Invite Link",
                $"Beep boop, https://discordapp.com/oauth2/authorize?client_id=398166771229786132&scope=bot.");
            embed.WithColor(Color.Blue);
            embed.AddField("Developed By Dakpan", "Support Server: https://discord.gg/UeBwppF");
            try
            {
                //await guild.DefaultChannel.SendMessageAsync("", false, embed.Build());
            }
            catch
            {
                //
            }
        }
    }
}
