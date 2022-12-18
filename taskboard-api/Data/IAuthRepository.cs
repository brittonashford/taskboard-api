using taskboard_api.DTOs.User;

namespace taskboard_api.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
        Task<ServiceResponse<User>> GetUser(int userID);
    }
}
