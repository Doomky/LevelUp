using LevelUpAPI.Dbo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.GoogleFit
{
    public class GoogleFitService
    {
         public static async Task<ListSessionstResponse> ListSessions(User user, ListSessionsRequest listSessionsRequest)
         {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", user.GoogleAccessToken);
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(URL.BASE_URL + "sessions");
            string ListSessionstResponseJSON = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ListSessionstResponse>(ListSessionstResponseJSON);
         }
    }
}
