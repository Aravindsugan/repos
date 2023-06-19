using System.Text;

namespace WebApplication1.CustomClient
{
    public class CustomHttpClient : ICustomHttpClient
    {
        private readonly HttpClient _httpClient;

        public CustomHttpClient(string baseAddress)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseAddress);
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await _httpClient.GetAsync(url);
        }

        public async Task<HttpResponseMessage> PostJsonAsync<T>(string url, T requestBody)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(url, content);

            return response;
        }
    }
}