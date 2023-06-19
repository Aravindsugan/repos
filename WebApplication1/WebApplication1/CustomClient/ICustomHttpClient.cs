namespace WebApplication1.CustomClient
{
    public interface ICustomHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> PostJsonAsync<T>(string url, T requestBody);
    }
}