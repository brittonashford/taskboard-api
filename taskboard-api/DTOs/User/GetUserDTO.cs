namespace taskboard_api.DTOs.User
{
    public class GetUserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public Models.UserRole UserRole { get; set; }
    }
}
