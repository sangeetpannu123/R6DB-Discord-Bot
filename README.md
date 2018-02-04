# R6DB-Discord-Bot
An Unofficial R6DB Discord Bot, developed in DotNetCore 2.0 as a Console Application.

# Customer Installation
[Click Here](https://discordapp.com/oauth2/authorize?client_id=405862980132143106&scope=bot&permissions=19456)

# Developer Installation
- Pull or clone the project into your Visual Studio 2017
- Add a file called "_configuration.json" in the root of the project
- Add the following content and fill it in with your own credentials.
```
{
  "prefix": "r6db ",
  "client-id": "[Your client-id]",
  "x-app-id": "[Your R6DB App-id]",
  "r6db_url": "https://r6db.com/api/v2",
  "db-org-token": "[Your Discordbot.org token]",
  "tokens": {
    "discord": "[Your discord secret]"
  }
}
```
Key | Value | Explaination
--- | --- | ---
client-id | 756fhg74h0-hg87-h84d-059a8dhe48be | [Discord Explained](https://discordapp.com/developers/docs/topics/oauth2)
x-app-id | Anything you want | Request R6DB devs on discord
db-org-token | token | The token you got from discordbot.org 
discord | 98d7gf89df7g89gfg79fdgfd987fdg7 | [Discord Explained](https://github.com/reactiflux/discord-irc/wiki/Creating-a-discord-bot-&-getting-a-token)

- Have fun building!

# Features
- [X] Get Ranked Information
- [X] Get Casual Information
- [X] Write Documentation
- [X] Get Help Information
  - [X] Show possible functions
  - [X] Get Invite Link
  - [X] Get Support Link
  - [X] Get Contribute Link
  - [X] Submit bugs/feedback
  - [X] Get number of active "guilds"
- [X] Get Operator Information
- [X] Get Game Mode Information
- [ ] Get General player statistics
- [ ] Get Seasonal stats
- [ ] Get a summary of the most used statistics
- [ ] Get Leaderboard
- [ ] Get a graph of the players MMR flow
  - [ ] Option for X number of matches
  - [ ] Option for X number of days
  - [ ] Make the graph animated instead of static.
- [ ] Option to compare players
- [X] **in beta** Option to fill in a player or match ESL link & get full stats on all involved players.
- [ ] Be able to "register" to get information about yourself faster
- [ ] Be able to create a "guild" leaderboard for registered people in the "guild"

# Contribute
Other ways to contribute than developing would be by giving feedback, tracking bugs or supporting me financially!

# Support
You can support me by donating money to my [Paypal](https://www.paypal.me/Dakpan).
