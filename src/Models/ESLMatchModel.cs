using System;
using System.Collections.Generic;
using System.Text;

namespace R6DB_Bot.Models
{
    public class ESLMatchModel
    {
        public string MatchName { get; set; }

        public string MatchID { get; set; }

        public string MatchURL { get; set; }

        public string MatchDate { get; set; }

        public string MatchCalculated { get; set; }

        public List<string> MatchMaps { get; set; }

        public int BestOF { get; set; }

        public int MatchResultTeam1 { get; set; }

        public int MatchResultTeam2 { get; set; }

        public string MatchResultWinnerText { get; set; }

        public List<ESLWireModel> ESLWires { get; set; }

        public List<ESLTeamModel> Teams { get; set; }
    }
}
