using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using R6DB_Bot.Enums;
using R6DB_Bot.Extensions;
using R6DB_Bot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace R6DB_Bot.Services
{
    public static class PlayerService
    {
        private static RegionEnum regionEnum;
        private static PlatformEnum platformEnum;

        static PlayerService() {
            regionEnum = RegionEnum.EMEA;
            platformEnum = PlatformEnum.PC;

        }

        public static async Task<PlayerModel> GetPlayerInfoFromR6DB(string text, string baseUrl, string xAppId)
        {
            var requestUri = $"{baseUrl}/Players";

            var region = regionEnum.GetAttribute<RegionInformation>().Description;
            var platform = platformEnum.GetAttribute<PlatformInformation>().Description;
            var technicalPlatform = platformEnum.GetAttribute<PlatformInformation>().TechnicalName;

            var queryParams = new List<KeyValuePair<string, string>>();
            queryParams.Add(new KeyValuePair<string, string>("name", text));
            queryParams.Add(new KeyValuePair<string, string>("platform", technicalPlatform));
            queryParams.Add(new KeyValuePair<string, string>("exact", "true")); //to make sure the name is exactly this. TODO: change this later into less exact with intelligence for questions like "did you mean.... "

            var response = await HttpRequestFactory.Get(requestUri, xAppId, queryParams);
            var responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error from R6DB API, code: " + response.StatusCode + " text: " + responseString);
            }

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            var outputModel = JsonConvert.DeserializeObject<IList<PlayerModel>>(responseString, jsonSerializerSettings);

            if (outputModel.Count == 0)
            {
                return null;
            }

            //Find the best match, if there isn't anyone with this exact name, than return the first one we found (likely to be the best)
            var model = new PlayerModel();
            model = outputModel.Where(m => m.name.ToLower() == text.ToLower()).FirstOrDefault();

            if (model == null)
            {
                //await ReplyAsync($"We found **{outputModel.Count}** likely results for the name **{text}** if the folowing stats are not the once you are looking for, please be more specific with the name/region/platform.");
                model = outputModel.FirstOrDefault();

                if (outputModel.Count > 1)
                {
                    model.guessed = new GuessedModel
                    {
                        IsGuessed = true,
                        PlayersFound = outputModel.Count
                    };
                }
            }

            var playerURL = $"{baseUrl}/Players/{model.id}";

            var queryParams2 = new List<KeyValuePair<string, string>>();
            var response2 = await HttpRequestFactory.Get(playerURL, xAppId, queryParams2);
            var responseString2 = await response2.Content.ReadAsStringAsync();

            if (!response2.IsSuccessStatusCode)
            {
                throw new Exception("Error from R6DB API, code: " + response2.StatusCode + " text: " + responseString2);
            }

            var jsonSerializerSettings2 = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            var fullModel = JsonConvert.DeserializeObject<PlayerModel>(responseString2, jsonSerializerSettings2);
            fullModel.guessed = model.guessed;
            return fullModel;
        }
    }
}
