using System.Globalization;

namespace API.Application.DTOs
{
    public class UsersDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string? Phone { get; set; }
        public string CreatedBy { get; set; }
        public int RoleId { get; set; }
        public string ProfileImageURL { get; set; }
        public bool IsEmailVerified { get; set; }
    }
}
