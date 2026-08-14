using Server.Application.DTOs;
using Server.Domain.Entities.Core;
using Server.Domain.Models.Core;
using Server.Infrastructure.DAL.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Server.Infrastructure.DAL
{
    public class UsersDAL : IUsersDAL
    {
        private readonly string _connectionString;

        public UsersDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Method to get all users
        /// </summary>
        /// <param name="filterData"></param>
        /// <returns></returns>
        public async Task<List<Users>> GetUsersData(FilterData filterData)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    List<Users> response = new List<Users>();
                    var parameters = new DynamicParameters();
                    parameters.Add("@value1", "select");
                    parameters.Add("@fdate", filterData.FromDate);
                    parameters.Add("@tdate", filterData.ToDate);
                    parameters.Add("@pageSize", filterData.Pagesize);
                    parameters.Add("@skip", filterData.Skip);
                    parameters.Add("@sqlSortString", filterData.SortString);
                    parameters.Add("@sqlFilterString", filterData.FilterString);

                    var usersData = await connection.QueryAsync<Users>(
                        "USP_UserGridData",
                        parameters,
                        commandType: CommandType.StoredProcedure
                        );
                    return usersData.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This method is for insert user in DB
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<Response> InsertUser(UsersDto user)
        {
            var response = new Response();
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@value", "insert");
                parameters.Add("@FirstName", user.FirstName);
                parameters.Add("@LastName", user.LastName);
                parameters.Add("@Email", user.Email);
                parameters.Add("@PasswordHash", user.PasswordHash);
                parameters.Add("@PasswordSalt", user.PasswordSalt);
                parameters.Add("@Phone", user.Phone);
                parameters.Add("@Role", user.RoleId);
                parameters.Add("@ProfileImageUrl", user.ProfileImageURL);
                parameters.Add("@IsEmailVerified", user.IsEmailVerified);
                parameters.Add("@CreatedBy", user.CreatedBy);

                var newId = await connection.ExecuteScalarAsync<int>(
                    "USP_Users",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
                if(newId == 0)
                {
                    response.IsSuccess = false;
                    response.Message = "User already exists!";
                } else
                {
                    response.IsSuccess = true;
                    response.Message = Convert.ToString(newId);
                }
                return response;
            }
        }

        public async Task<Users> GetById(Guid RecordId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@value", "GetById");
                parameters.Add("@RecordId", RecordId);

                var data = await connection.QueryFirstOrDefaultAsync<Users>(
                    "USP_Users",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return data;
            }
        }
    }
}
