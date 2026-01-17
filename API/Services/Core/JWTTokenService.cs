using API.Models.Core;
using API.Services.Interfaces;
using Azure.Core;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace API.Services.Core
{
    public class JWTTokenService: IJWTTokenService
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        public JWTTokenService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _configuration = configuration;
        }

        /// <summary>
        /// This service method to generate token for user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public RefreshTokenModel GenerateToken(LoginResponse user)
        {
            var secretKey = _configuration["Jwt:Key"];
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var tokenValidityMin = Convert.ToDouble(_configuration["Jwt:TokenValidityMin"]);
            var refreshTokenValidityMin = Convert.ToDouble(_configuration["Jwt:RefreshTokenValidityMin"]);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("FullName", user.UserName ?? ""),
                new Claim(ClaimTypes.Role, user.RoleName ?? "User"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),      // Token expiry
                signingCredentials: credentials
            );

            var refreshToken = new RefreshTokenModel
            {
                RefreshToken = GenerateRefreshToken(),
                Expires = DateTime.UtcNow.AddMinutes(refreshTokenValidityMin),
                //Revoked = false
            };

            //return new JwtSecurityTokenHandler().WriteToken(token);
            return new RefreshTokenModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = refreshToken.RefreshToken,
                Expires = refreshToken.Expires
            };
        }

        private string GenerateRefreshToken()
        {
            var randomBytes = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }
    }
}
