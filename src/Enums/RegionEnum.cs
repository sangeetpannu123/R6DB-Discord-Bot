using R6DB_Bot.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace R6DB_Bot.Enums
{
    public enum RegionEnum
    {
        [RegionInformation("Europe")]
        EMEA = 0,

        [RegionInformation("America")]
        NCSA = 1,

        [RegionInformation("ASIA")]
        APAC = 2,
    }
}
