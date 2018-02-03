using R6DB_Bot.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace R6DB_Bot.Extensions
{
    public static class StringVisualiser
    {
        public static string ToReadablePlaytime(TimeSpan span)
        {
            string formatted = string.Format("{0}{1}{2}{3}",
                span.Duration().Days > 0 ? string.Format("{0:0} day{1} ", span.Days, span.Days == 1 ? String.Empty : "s") : string.Empty,
                span.Duration().Hours > 0 ? string.Format("{0:0} hour{1} " + Environment.NewLine, span.Hours, span.Hours == 1 ? String.Empty : "s") : string.Empty,
                span.Duration().Minutes > 0 ? string.Format("{0:0} minute{1} ", span.Minutes, span.Minutes == 1 ? String.Empty : "s") : string.Empty,
                span.Duration().Seconds > 0 ? string.Format("{0:0} second{1} ", span.Seconds, span.Seconds == 1 ? String.Empty : "s") : string.Empty,
                span.Duration().TotalHours > 0 ? string.Format("{0:0} total hour{1} ", span.TotalHours, span.TotalHours == 1 ? String.Empty : "s") : string.Empty);

            if (string.IsNullOrEmpty(formatted))
            {
                formatted = "0 seconds";
            }

            return formatted;
        }
        public static string ToReadablePlaytimeHours(TimeSpan span)
        {
            string formatted = string.Format("{0}", span.Duration().TotalHours > 0 ? string.Format("{0:0} hour{1} ", span.TotalHours, span.TotalHours == 1 ? String.Empty : "s") : string.Empty);

            if (string.IsNullOrEmpty(formatted))
            {
                formatted = "0 seconds";
            }

            return formatted;
        }


        public static int CeilingRankMMR(int? rank_nr)
        {
            rank_nr = rank_nr ?? 0;
            var rankEnum = (RankEnum)rank_nr;
            var info = rankEnum.GetAttribute<RankInformation>();
            return info.MMR;
        }

        public static string ToReadableRank(int? rank_nr)
        {
            rank_nr = rank_nr ?? 0;
            var rankEnum = (RankEnum)rank_nr;
            var info = rankEnum.GetAttribute<RankInformation>();
            return info.Description;
        }

        public static string GetRankImage(int? rank_nr)
        {
            rank_nr = rank_nr ?? 0;
            var rankEnum = (RankEnum)rank_nr;
            var info = rankEnum.GetAttribute<RankInformation>();
            return info.URL;
        }

        public static string GetRatio(int? min, int? max)
        {
            if (min == 0 || min == null || max == 0 || max == null)
            {
                return "0";
            }
            return ((decimal)min / (decimal)max).ToString("#.##");
        }
    }
}
