using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary
{
    public class VillagerProcessor2
    {
        public static async Task<VillagerModel2> LoadVillager(int villagerID)
        {
            string url = "";

            if (villagerID == 0)
            {
                url = "http://acnhapi.com/villagers/";
            }
            else
            {
                url = $"http://acnhapi.com/villagers/{villagerID}";
            }

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    VillagerModel2 villager = await response.Content.ReadAsAsync<VillagerModel2>();
                    return villager;

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
