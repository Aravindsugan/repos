using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IUserService
    {
        Task<UserDetails> GetUserDetails(int id);
        Task<CreateUserResponse> CreateUser(CreateUserRequest createUserRequest);
    }
}
