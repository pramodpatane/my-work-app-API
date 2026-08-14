using Server.Domain.Models.Core;
using Server.Infrastructure.DAL.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;

namespace Server.Infrastructure.DAL
{
    public class AppMenusDAL : IAppMenusDAL
    {
        private readonly string _connectionString;
        public AppMenusDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<List<AuthMenusViewModel>> GetAppMenusAsync(Guid userGuid)
        {
            using var con = new SqlConnection(_connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("@value1", "getUserMenus");
            parameters.Add("@UserRecordId", userGuid);

            var result = await con.QueryAsync<AuthMenusViewModel>(
                "USP_UserAppMenus",
                parameters,
                commandType: CommandType.StoredProcedure);

            var menus = result.ToList();

            foreach (var menu in menus)
            {
                if (!string.IsNullOrWhiteSpace(menu.ChildMenus))
                {
                    menu.Children = JsonConvert.DeserializeObject<List<AuthMenusViewModel>>(menu.ChildMenus);
                }
            }

            return menus.ToList();
        }
    }
}
