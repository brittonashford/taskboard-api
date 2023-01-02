using taskboard_api.DTOs.User;
using taskboard_api.DTOs.UserRole;

namespace taskboard_api.Repositories.Auth
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password, int requestedRoleId);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
        Task<ServiceResponse<User>> GetUser(int userID);
        Task<ServiceResponse<int>> GetUserRoleId(int userID);
        Task<ServiceResponse<List<GetUserRoleDTO>>> GetAllUserRoles();
    }
}
