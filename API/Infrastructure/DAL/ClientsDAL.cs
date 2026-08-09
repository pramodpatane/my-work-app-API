using API.Application.DTOs;
using API.Domain.Entities.Core;
using API.Domain.Models.Core;
using API.Domain.Models.Feature;
using API.Infrastructure.DAL.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API.Infrastructure.DAL
{
    public class ClientsDAL : IClientsDAL
    {
        private readonly string _connectionString;

        public ClientsDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<ClientsGridResponse> GetAllData(FilterData filterData)
        {
            try
            {
                ClientsGridResponse response = new ClientsGridResponse();

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
                        "USP_ClientsGridData",
                        parameters,
                        commandType: CommandType.StoredProcedure))
                    {
                        response.Data = (await multi.ReadAsync<ClientsViewModel>()).ToList();
                        response.TotalCount = await multi.ReadFirstAsync<int>();
                        response.ThisMonthTotal = await multi.ReadFirstAsync<int>();
                    }
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ClientsViewModel> GetById(Guid recordId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@value1", "GetById");
                parameters.Add("@RecordId", recordId);

                var data = await connection.QueryFirstOrDefaultAsync<ClientsViewModel>(
                    "USP_Clients",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return data;
            }
        }

        public async Task<Response> Create(Clients model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@value1", "insert");
                parameters.Add("RecordId", Guid.NewGuid());
                parameters.Add("@clientCode", model.ClientCode);
                parameters.Add("@firstname", model.FirstName);
                parameters.Add("@lastname", model.LastName);
                parameters.Add("@clientType", model.ClientType);
                parameters.Add("@category", model.Category);
                parameters.Add("@username", model.UserName);
                parameters.Add("@address", model.Address);
                parameters.Add("@email", model.Email);
                parameters.Add("@mobile", model.Mobile);
                parameters.Add("@alternateMobile", model.AlternateMobile);
                parameters.Add("@TaxId", model.TaxId);
                parameters.Add("@useremail", model.CreatedBy);

                var data = await connection.ExecuteScalarAsync<int>(
                    "USP_Clients",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return new Response { IsSuccess = data > 0 };
            }
        }

        public async Task<Response> Update(Clients model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@value1", "update");
                parameters.Add("RecordId", model.RecordId);
                parameters.Add("@clientCode", model.ClientCode);
                parameters.Add("@firstname", model.FirstName);
                parameters.Add("@lastname", model.LastName);
                parameters.Add("@clientType", model.ClientType);
                parameters.Add("@category", model.Category);
                parameters.Add("@username", model.UserName);
                parameters.Add("@address", model.Address);
                parameters.Add("@email", model.Email);
                parameters.Add("@mobile", model.Mobile);
                parameters.Add("@alternateMobile", model.AlternateMobile);
                parameters.Add("@TaxId", model.TaxId);
                parameters.Add("@useremail", model.UpdatedBy);

                var data = await connection.ExecuteScalarAsync<int>(
                    "USP_Clients",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return new Response { IsSuccess = data > 0, Message = "Record Updated Successfully!" };
            }
        }

        public async Task<Response> Delete(Clients model)
        {
            await using var connection = new SqlConnection(_connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@VALUE1", "delete");
            parameters.Add("@useremail", model.UpdatedBy);
            parameters.Add("@RecordId", model.RecordId);

            var result = await connection.QueryFirstOrDefaultAsync<int>(
                "USP_Clients",
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

        public async Task<List<DropdownModel>> GetClientsDropdown()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@value1", "getDropdown");

                var data = await connection.QueryAsync<DropdownModel>(
                    "USP_Clients",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return data.ToList();
            }
        }
    }
}
