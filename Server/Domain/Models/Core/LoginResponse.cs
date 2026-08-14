using Server.Domain.Entities.Core;

namespace Server.Domain.Models.Core
{
    public class LoginResponse : Response
    {
        public string? Id { get; set; }
        public Guid RecordId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? RoleName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string? Token { get; set; }
        public DateTime ExpiresIn { get; set; }
        public string? RefreshToken { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string? ProfilePhotoUrl { get; set; }
    }
}
