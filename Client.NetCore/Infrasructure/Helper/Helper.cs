using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Client.NetCore.Infrasructure.Helper
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

        public static string GetToken(string partner_key, string request_id)
        {
            string hashBase64 = "";

            byte[] message = Encoding.UTF8.GetBytes(request_id);
            byte[] keyByte = Encoding.UTF8.GetBytes(partner_key);

            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(message);
                hashBase64 = Convert.ToBase64String(hashmessage);
            }

            return hashBase64;
        }

    }
}
