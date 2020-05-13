using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary
{
    public class BugProcessor
    {
        public static async Task<BugModel> LoadBug(int bugID)
        {
            string url = "";


            if (bugID == 0)
            {
                url = "http://acnhapi.com/bug";
            }
            else
            {
                url = $"http://acnhapi.com/bug/{bugID}";
            }

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    BugResultsModel bug = await response.Content.ReadAsAsync<BugResultsModel>();
                    return bug.Name;

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }


        }



    }
}
