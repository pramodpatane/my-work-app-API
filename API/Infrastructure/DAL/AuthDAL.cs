using API.Domain.Models.Core;
using API.Infrastructure.DAL.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace API.Infrastructure.DAL
{
    public class AuthDAL: IAuthDAL
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        public AuthDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _configuration = configuration; 
        }

        /// <summary>
        /// This method to convert password into PasswordHash and PasswordSalt
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;                 // auto-generated salt
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        /// <summary>
        /// To check entered user is exist or not
        /// </summary>
        /// <param name="useremail"></param>
        /// <returns></returns>
        public async Task<int> IsUserExist(string useremail)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@value", "ValidateUser");
                parameters.Add("@userEmail", useremail);

                var newId = await connection.ExecuteScalarAsync<int>(
                    "USP_UserLogin",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
                return newId;
            }
        }

        /// <summary>
        /// Get user details by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<LoginResponse> GetUserByEmail(string email)
        {
            using var con = new SqlConnection(_connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@value", "GetUserByEmail");
            parameters.Add("@userEmail", email);

            return await con.QueryFirstOrDefaultAsync<LoginResponse>(
                "USP_UserLogin",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
