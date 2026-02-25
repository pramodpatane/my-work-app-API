
namespace API.Models.Core
{
    public class Users: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }    
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string? Phone { get; set; }
        public int RoleId { get; set; }        
        public string Role { get; set; }
        public string ProfileImageURL { get; set; }
        public bool IsEmailVerified { get; set; }           
    }
}
