using API.DAL.Interfaces;
using API.Models.Core;
using API.Models.Feature;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API.DAL
{
    public class EmployeeDAL: IEmployeeDAL
    {
        private readonly string _connectionString;

        public EmployeeDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<EmployeeViewModel>> GetEmployeesData(FilterData filterData)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    List<EmployeeViewModel> response = new List<EmployeeViewModel>();
                    var parameters = new DynamicParameters();
                    parameters.Add("@value1", "select");
                    parameters.Add("@fdate", filterData.FromDate);
                    parameters.Add("@tdate", filterData.ToDate);
                    parameters.Add("@pageSize", filterData.Pagesize);
                    parameters.Add("@skip", filterData.Skip);
                    parameters.Add("@sqlSortString", filterData.SortString);
                    parameters.Add("@sqlFilterString", filterData.FilterString);

                    var employeeData = await connection.QueryAsync<EmployeeViewModel>(
                        "USP_EmployeeGridData",
                        parameters,
                        commandType: CommandType.StoredProcedure
                        );
                    return employeeData.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
