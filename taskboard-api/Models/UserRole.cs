namespace taskboard_api.Models
{
    public class UserRole
    {
        public int UserRoleId { get; set; } 
        public string RoleType { get; set; }
        public List<User> UsersInRole { get; set; }
    }
}
