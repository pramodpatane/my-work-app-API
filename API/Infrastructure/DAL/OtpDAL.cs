using API.Domain.Entities.Core;
using API.Infrastructure.DAL.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API.Infrastructure.DAL
{
    public class OtpDAL : IOtpDAL
    {
        private readonly string _connectionString;
        public OtpDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<Response> SaveOtp(string email, string otp)
        {
            var response = new Response();
            using (var connection = new SqlConnection(_connectionString))
            {
                var expiry = DateTime.Now.AddMinutes(5);

                var parameters = new DynamicParameters();
                parameters.Add("@value1", "Insert");
                parameters.Add("@Email", email);
                parameters.Add("@Otp", otp);
                parameters.Add("@ExpiryTime", expiry);

                var result = await connection.ExecuteScalarAsync<int>(
                    "USP_OTPDetails",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
                if (result == 0)
                {
                    response.IsSuccess = false;
                    response.Message = string.Empty;
                }
                else {
                    response.IsSuccess = true;
                    response.Message = "OTP Saved!";
                }
                return response;
            }
        }

        public async Task<bool> VerifyOtp(string email, string otp)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@value1", "VerifyOtp");
                parameters.Add("@Email", email);
                parameters.Add("@Otp", otp);

                var response = await connection.ExecuteScalarAsync<int>(
                    "USP_OTPDetails",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return Convert.ToBoolean(response);
            }
        }
    }
}
