using API.DAL.Interfaces;
using API.Models.Core;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API.DAL
{
    public class DepartmentDAL: IDepartmentDAL
    {
        private readonly string _connectionString;
        public DepartmentDAL(IConfiguration configuration)
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
                    parameters.Add("@value1", "GetDepartmentsDropdown");

                    var dropdownResponse = await connection.QueryAsync<DropdownModel>(
                        "USP_Departments",
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
