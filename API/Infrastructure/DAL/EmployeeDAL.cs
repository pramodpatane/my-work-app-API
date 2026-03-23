using API.Domain.Models.Core;
using API.Domain.Models.Feature;
using API.Infrastructure.DAL.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API.Infrastructure.DAL
{
    public class EmployeeDAL: IEmployeeDAL
    {
        private readonly string _connectionString;

        public EmployeeDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<GridResponse<EmployeeViewModel>> GetEmployeesData(FilterData filterData)
        {
            try
            {
                GridResponse<EmployeeViewModel> response = new GridResponse<EmployeeViewModel>();

                using (var connection = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@value1", "select");
                    parameters.Add("@fdate", filterData.FromDate);
                    parameters.Add("@tdate", filterData.ToDate);
                    parameters.Add("@pageSize", filterData.Pagesize);
                    parameters.Add("@skip", filterData.Skip);
                    parameters.Add("@sqlSortString", filterData.SortString);
                    parameters.Add("@sqlFilterString", filterData.FilterString);

                    using (var multi = await connection.QueryMultipleAsync(
                        "USP_EmployeeGridData",
                        parameters,
                        commandType: CommandType.StoredProcedure))
                    {
                        response.Data = (await multi.ReadAsync<EmployeeViewModel>()).ToList();
                        response.TotalCount = await multi.ReadFirstAsync<int>();
                    }
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<EmployeeViewModel> GetById(Guid recordId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@value1", "GetById");
                parameters.Add("@RecordId", recordId);

                var data = await connection.QueryFirstOrDefaultAsync<EmployeeViewModel>(
                    "USP_Employees",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return data;
            }
        }

        public async Task<int> Create(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@value1", "insert");
                parameters.Add("@fname", employee.FirstName);
                parameters.Add("@lname", employee.LastName);
                parameters.Add("@email", employee.Email);
                parameters.Add("@salary", employee.Salary);
                parameters.Add("@department", employee.DepartmentId);
                parameters.Add("@user", employee.CreatedBy);
                parameters.Add("@RecordId", employee.RecordId);

                var data = await connection.ExecuteScalarAsync<int>(
                    "USP_Employees",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return data;
            }
        }

        public async Task<int> Update(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@value1", "update");
                parameters.Add("@fname", employee.FirstName);
                parameters.Add("@lname", employee.LastName);
                parameters.Add("@email", employee.Email);
                parameters.Add("@salary", employee.Salary);
                parameters.Add("@department", employee.DepartmentId);
                parameters.Add("@user", employee.CreatedBy);
                parameters.Add("@RecordId", employee.RecordId);

                var data = await connection.ExecuteScalarAsync<int>(
                    "USP_Employees",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return data;
            }
        }

        public async Task<Response> Delete(Employee employee)
        {
            await using var connection = new SqlConnection(_connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@value1", "delete");
            parameters.Add("@user", employee.CreatedBy);
            parameters.Add("@RecordId", employee.RecordId);

            var result = await connection.QueryFirstOrDefaultAsync<int>(
                "USP_Employees",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            if (result <= 0)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Record not deleted!"
                };
            }

            return new Response
            {
                IsSuccess = true,
                Message = "Record deleted successfully!"
            };
        }
    }
}
