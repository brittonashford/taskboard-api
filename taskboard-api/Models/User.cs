using System.Reflection.Metadata.Ecma335;

namespace taskboard_api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int UserRoleId { get; set; }  
    }
}
