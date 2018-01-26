using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace R6DB_Bot.Extensions
{
    [AttributeUsage(AttributeTargets.All)]
    public class RankInformation : DescriptionAttribute
    {
        public RankInformation(string description, string url, int elo)
        {
            this.Description = description;
            this.URL = url;
            this.ELO = elo;
        }

        public string Description { get; set; }
        public string URL { get; set; }
        public int ELO { get; set; }
    }
}
