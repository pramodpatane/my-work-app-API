using API.Models.Core;

namespace API.DAL.Interfaces
{
    public interface IAuthDAL
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        
        public Task<int> IsUserExist(string useremail);

        public Task<LoginResponse> GetUserByEmail(string email);

        string GenerateToken(LoginResponse user);
    }
}
