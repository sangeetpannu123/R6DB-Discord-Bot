using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace R6DB_Bot.Extensions
{
    [AttributeUsage(AttributeTargets.All)]
    public class PlatformInformation : DescriptionAttribute
    {
        public PlatformInformation(string description, string technicalName)
        {
            this.Description = description;
            this.TechnicalName = technicalName;
        }

        public string Description { get; set; }
        public string TechnicalName { get; set; }
    }
}
