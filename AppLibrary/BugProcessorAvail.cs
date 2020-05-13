using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary
{
    public class BugProcessorAvail
    {
        public static async Task<BugModelAvil> LoadBugAvil(int bugID)
        {
            string url = "";


            if (bugID == 0)
            {
                url = "http://acnhapi.com/bugs/";
            }
            else
            {
                url = $"http://acnhapi.com/bugs/{bugID}";
            }

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    BugResultsModelAvil bugAvil = await response.Content.ReadAsAsync<BugResultsModelAvil>();
                    return bugAvil.Availability;

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }


        }



    }
}
