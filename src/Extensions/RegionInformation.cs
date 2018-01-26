using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace R6DB_Bot.Extensions
{
    [AttributeUsage(AttributeTargets.All)]
    public class RegionInformation : DescriptionAttribute
    {
        public RegionInformation(string description)
        {
            this.Description = description;
        }

        public string Description { get; set; }
    }
}
