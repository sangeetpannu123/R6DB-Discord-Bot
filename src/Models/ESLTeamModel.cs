using System;
using System.Collections.Generic;
using System.Text;

namespace R6DB_Bot.Models
{
    public class ESLTeamModel
    {
        public string TeamName { get; set; }

        public string TeamID { get; set; }

        public string TeamURL { get; set; }

        public List<ESLPlayerModel> Players { get; set; }

        public List<ESLPlayerModel> MatchLineUp { get; set; }
    }
}
