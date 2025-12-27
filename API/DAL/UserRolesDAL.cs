using API.DAL.Interfaces;
using API.Models.Core;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API.DAL
{
    public class UserRolesDAL: IUserRolesDAL
    {
        private readonly string _connectionString;

        public UserRolesDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<DropdownModel>> GetDropdown()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@value1", "GetUserDropdown");

                    var dropdownResponse = await connection.QueryAsync<DropdownModel>(
                        "USP_UserRoles",
                        parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    return dropdownResponse.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
