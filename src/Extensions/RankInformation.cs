using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace R6DB_Bot.Extensions
{
    [AttributeUsage(AttributeTargets.All)]
    public class RankInformation : DescriptionAttribute
    {
        public RankInformation(string description, string url, int mmr)
        {
            this.Description = description;
            this.URL = url;
            this.MMR = mmr;
        }

        public string Description { get; set; }
        public string URL { get; set; }
        public int MMR { get; set; }
    }
}
