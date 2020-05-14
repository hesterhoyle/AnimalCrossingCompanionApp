using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary
{
    public class VillagerModel2
    {
        public string Personality { get; set; }

        [JsonProperty("birthday-string")]
        public string Birthday { get; set; }

        public string Gender { get; set; }

        public string Species { get; set; }
    }
}
