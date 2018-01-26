using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace R6DB_Bot.Extensions
{
    [AttributeUsage(AttributeTargets.All)]
    public class OperatorInformation : DescriptionAttribute
    {
        public OperatorInformation(string description, string url)
        {
            this.Description = description;
            this.URL = url;
        }

        public string Description { get; set; }
        public string URL { get; set; }
    }
}
