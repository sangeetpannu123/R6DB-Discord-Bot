using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using R6DB_Bot.Services;
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
            await _discordClient.SetGameAsync("use r6db help for info.");
            await _discordClient.SetStatusAsync(UserStatus.Online);
            //_discordClient.JoinedGuild += _client_JoinedGuild;

            await Task.Delay(-1);     // Prevent the application from closing
        }

        public int CountGuilds()
        {
            return _discordClient.Guilds.Count;
        }

        public async Task OnMessageReceivedAsync(SocketMessage parameterMessage)
        {
            if (!(parameterMessage is SocketUserMessage message)) return;
            var argPos = 0;
            var context = new SocketCommandContext(_discordClient, message); 

            if (context.User.IsBot)
                return;

            if (!(message.HasMentionPrefix(_discordClient.CurrentUser, ref argPos) ||
                  message.HasStringPrefix(Prefix, ref argPos))) return;
            
        }
    }
}
