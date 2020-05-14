using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary
{
    // model to pull the various availability information for the fish from the API
    public class FishModelAvil
    {

        [JsonProperty("isAllYear")]
        public bool AllYear { get; set; }

        [JsonProperty("month-northern")]
        public string MonthNorth { get; set; }

        [JsonProperty("month-southern")]
        public string MonthSouth { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("isAllDay")]
        public bool AllDay { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }
    }
}
