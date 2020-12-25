using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PrefixIDClient.NetMVC.Infrasructure
{
    public static class Helper
    {
        public static async Task<T> ReadAsJsonAsync<T>(HttpClient httpClient, string uri, string token)
        {
            if (token != "" && !httpClient.DefaultRequestHeaders.Contains("X-TOKEN"))
                httpClient.DefaultRequestHeaders.Add("X-TOKEN", token);

            var httpResponse = await httpClient.GetAsync(uri);
            var dataAsString = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(dataAsString);
        }

        public static async Task<T> PostAsJsonAsync<T>(HttpClient httpClient, string uri, object data, string token)
        {
            if (token != "" && !httpClient.DefaultRequestHeaders.Contains("X-TOKEN"))
                httpClient.DefaultRequestHeaders.Add("X-TOKEN", token);

            string content = JsonConvert.SerializeObject(data);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");

            var httpResponse = await httpClient.PostAsync(uri, httpContent);

            var dataAsString = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(dataAsString);
        }

    }
}
