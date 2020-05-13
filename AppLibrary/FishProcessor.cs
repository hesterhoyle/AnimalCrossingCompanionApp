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
        public static async Task<FishModel> LoadFish(int fishID)
        {
            string url = "";


            if (fishID == 0)
            {
                url = "http://acnhapi.com/fish/";
            }
            else
            {
                url = $"http://acnhapi.com/fish/{fishID}";
            }

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    FishResultsModel fish = await response.Content.ReadAsAsync<FishResultsModel>();
                    return fish.Name;

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }


        }



    }
}
