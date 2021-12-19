using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Configurations
{
    public class EmailOptions
    {
        [JsonProperty("Mail")]
        public string Mail { get; set; }
        
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("")]
        public string Password { get; set; }
        [JsonProperty("")]
        public string Host { get; set; }
        [JsonProperty("")]
        public int Port { get; set; }
    }
}
