using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webappdemo2.Models
{
    using Newtonsoft.Json;
    public class Item
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
}
