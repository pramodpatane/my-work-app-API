using API.DAL.Interfaces;
using API.Models.Core;
using API.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace API.Services.Core
{
    public class AuthService: IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthDAL _authDAL;
        public AuthService(IConfiguration configuration, IAuthDAL authDAL) 
        {
            _configuration = configuration;
            _authDAL = authDAL;
        }

        /// <summary>
        /// This service method to Login user
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<LoginResponse> Login(Login login)
        {
            try
            {
                var response = new LoginResponse();
                var isUserExist = await _authDAL.IsUserExist(login.Useremail);

                if (Convert.ToInt32(isUserExist) == 2)
                {
                    response.IsSuccess = false;
                    response.Message = "EmailId is not verified.";
                    return response;
                }                    

                if (Convert.ToInt32(isUserExist) == 0)
                {
                    //throw new Exception("Invalid email or password.");
                    response.IsSuccess = false;
                    response.Message = "Invalid email or password.";
                    return response;
                }

                if (Convert.ToInt32(isUserExist) == 1)
                {
                    var user = await _authDAL.GetUserByEmail(login.Useremail);

                    if (user == null)
                        throw new Exception("Invalid email or password.");

                    if (!VerifyPassword(login.Password, user.PasswordHash, user.PasswordSalt))
                        throw new Exception("Invalid email or password.");

                    var token = _authDAL.GenerateToken(user);

                    //var loginResponse = new LoginResponse
                    //{
                    response.Token = token;
                    response.Id = user.Id;
                    response.Email = user.Email;
                    response.UserName = user.UserName;
                    response.RoleName = user.RoleName;
                    response.IsActive = user.IsActive;
                    response.ProfilePhotoUrl = user.ProfilePhotoUrl;
                    //};

                    response.IsSuccess = true;
                    response.Message = "Login Succeed!";
                }

                return response;
                    
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// This service method to verify password salt and hash with DB stored
        /// </summary>
        /// <param name="password"></param>
        /// <param name="storedHash"></param>
        /// <param name="storedSalt"></param>
        /// <returns></returns>
        private bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt)
        {
            using var hmac = new HMACSHA512(storedSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return computedHash.SequenceEqual(storedHash);
        }

        private RefreshTokenModel GenerateRefreshToken(string ipAddress)
        {
            return new RefreshTokenModel
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow,
                CreatedByIp = ipAddress
            };
        }
    }
}
