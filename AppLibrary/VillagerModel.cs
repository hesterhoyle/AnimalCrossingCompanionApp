using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary
{
    public class VillagerModel
    {
        [JsonProperty("name-en")]
        public string NameEn { get; set; }

        

    }
}
