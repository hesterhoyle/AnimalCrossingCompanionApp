using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary
{
    public class FishProcessor
    {
        public string LoadFish()
        {
            string url = "http://acnhapi.com/fish/";
            return url;
        }

        public string LoadFish(string fish)
        {
            string url = $"http://acnhapi.com/fish/{fish}";
            return url;
        }

    }
}
