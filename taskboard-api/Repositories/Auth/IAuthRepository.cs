using taskboard_api.DTOs.User;
using taskboard_api.DTOs.UserRole;

namespace taskboard_api.Repositories.Auth
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password, string requestedRole);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
        Task<ServiceResponse<User>> GetUser(int userID);
        Task<ServiceResponse<GetUserRoleDTO>> GetUserRole(int userID);
        Task<ServiceResponse<List<GetUserRoleDTO>>> GetAllUserRoles();
        Task<ServiceResponse<UserRole>> FindUserRole(string requestedRole);
    }
}
