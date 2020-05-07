using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary
{
    public class VillagerProcessor
    {
        public static async Task<VillagerModel> LoadVillager(int villagerID)
        {
            string url = $"http://acnhapi.com/villagers/{villagerID}";

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    VillagerModel villager = await response.Content.ReadAsAsync<VillagerModel>();
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
