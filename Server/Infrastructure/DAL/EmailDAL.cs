using Server.Domain.Models.Core;
using Server.Infrastructure.DAL.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Server.Infrastructure.DAL
{
    public class EmailDAL : IEmailDAL
    {
        private readonly string _connectionString;
        public EmailDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<string> GetEmailConfiguration(string Code)
        {
            try
            {
                var response = new EmailConfigurationResponse();
                using (var connection = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@value1", "GetConfiguration");
                    parameters.Add("@code", Code);

                    var result = await connection.ExecuteScalarAsync<string>(
                        "USP_EmailConfiguration",
                        parameters,
                        commandType: CommandType.StoredProcedure
                    );
                    // Step 1: Deserialize outer response
                    //var apiResponse = JsonSerializer.Deserialize<Response>(result,
                    //    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    //if (apiResponse == null || !apiResponse.IsSuccess)
                    //    return null;

                    //// Step 2: Deserialize inner message JSON
                    //var emailConfig = JsonSerializer.Deserialize<EmailConfigurationResponse>(apiResponse.Message,
                    //    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
