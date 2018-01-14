﻿using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace R6DB_Bot
{
    public class PatchContent : StringContent
    {
        public PatchContent(object value)
            : base (JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json-patch+json")
        {
        }
    }
}
