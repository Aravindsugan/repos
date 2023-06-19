using Newtonsoft.Json;
using WebApplication1.CustomClient;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class UserService : IUserService
    {
        private readonly ICustomHttpClient _customHttpClient;

        public UserService()
        {
            _customHttpClient = new CustomHttpClient("https://reqres.in");
        }

        public UserService(ICustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public async Task<UserDetails> GetUserDetails(int id)
        {
            var apiPath = $"/api/users/{id}";

            try
            {
                var response = await _customHttpClient.GetAsync(apiPath);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var userDetails = JsonConvert.DeserializeObject<UserDetails>(json);

                    return userDetails;
                }
                else if ((int)response.StatusCode > 299 && (int)response.StatusCode < 400)
                {
                    Console.WriteLine("\nException Caught");
                    Console.WriteLine("Message :{0} ", "ReDirection");
                }
                else if ((int)response.StatusCode > 399 && (int)response.StatusCode < 500)
                {
                    Console.WriteLine("\nException Caught");
                    Console.WriteLine("Message :{0} ", "Client side error");
                }
                else if ((int)response.StatusCode > 499 && (int)response.StatusCode < 600)
                {
                    Console.WriteLine("\nException Caught");
                    Console.WriteLine("Message :{0} ", "Server side error");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return null;
        }

        public async Task<CreateUserResponse> CreateUser(CreateUserRequest createUserRequest)
        {
            var apiPath = $"/api/users";

            try
            {
                var response = await _customHttpClient.PostJsonAsync(apiPath, createUserRequest);

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var createdUser = JsonConvert.DeserializeObject<CreateUserResponse>(json);

                    return createdUser;
                }
                 else 
                {
                    return null;
                }

                
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return null;
        }
    }
}