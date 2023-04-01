using System.Net.Http.Headers;

namespace WeatherInfoAsPerCity
{
    public static class HttpClientHelper
    {
        public static async Task<HttpResponseMessage> GetAsync(string url, Dictionary<string, string> headers)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            foreach (var item in headers)
            {
                client.DefaultRequestHeaders.Add(item.Key, item.Value);
            }

            return await client.GetAsync(url);
        }
    }
}
