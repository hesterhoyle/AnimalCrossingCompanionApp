using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary
{
    //model to pull the name-en information for the fish from the API
    public class FishModel
    {
        [JsonProperty("name-en")]
        public string NameEn { get; set; }

        




    }
}
