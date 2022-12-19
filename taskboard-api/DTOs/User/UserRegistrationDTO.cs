namespace taskboard_api.DTOs.User
{
    public class UserRegistrationDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Models.UserRole UserRole { get; set; }  
    }
}
