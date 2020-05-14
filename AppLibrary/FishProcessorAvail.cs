using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary
{
    //processing the API for the fish availability 
    public class FishProcessorAvail
    {
        public static async Task<FishModelAvil> LoadFishAvil(int fishID)
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
                    FishResultsModelAvil fishAvil = await response.Content.ReadAsAsync<FishResultsModelAvil>();
                    return fishAvil.Availability;

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }


        }



    }
}
