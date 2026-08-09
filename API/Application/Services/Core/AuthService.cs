using API.Application.Interfaces;
using API.Domain.Entities.Core;
using API.Domain.Models.Core;
using API.Infrastructure.DAL.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace API.Application.Services.Core
{
    public class AuthService: IAuthService
    {
        private readonly IAuthDAL _authDAL;
        private readonly IJWTTokenService _jwtService;
        public AuthService(IAuthDAL authDAL, IJWTTokenService jwtService) 
        {
            _authDAL = authDAL;
            _jwtService = jwtService;
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
                var userExistRes = await _authDAL.IsUserExist(login.Useremail);

                if (Convert.ToInt32(userExistRes) == 2)
                {
                    response.IsSuccess = false;
                    response.Message = "User EmailId is not verified.";
                    return response;
                }                    

                if (Convert.ToInt32(userExistRes) == 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Invalid email or password.";
                    return response;
                }

                if (Convert.ToInt32(userExistRes) == 1)
                {
                    var user = await _authDAL.GetUserByEmail(login.Useremail);

                    if (user == null)
                        throw new Exception("Invalid email or password.");

                    if(!login.IsOtpVerified)
                    {
                        if (!VerifyPassword(login.Password, user.PasswordHash, user.PasswordSalt))
                            throw new Exception("Invalid email or password.");
                    }                    

                    var token = _jwtService.GenerateToken(user);
                                        
                    response.Token = token.Token;
                    response.RefreshToken = token.RefreshToken;
                    response.ExpiresIn = token.Expires;
                    response.Id = user.Id;
                    response.RecordId = user.RecordId;
                    response.Email = user.Email;
                    response.UserName = user.UserName;
                    response.RoleName = user.RoleName;
                    response.IsActive = user.IsActive;
                    response.ProfilePhotoUrl = user.ProfilePhotoUrl;
                    
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
    }
}
