using API.Application.Interfaces;
using API.Domain.Models.Core;
using API.Infrastructure.DAL.Interfaces;

namespace API.Application.Services.Core
{
    public class AppMenusService : IAppMenusService
    {
        private readonly IAppMenusDAL _appMenusDAL;
        public AppMenusService(IAppMenusDAL appMenusDAL)
        {
            _appMenusDAL = appMenusDAL;
        }
        public async Task<List<AuthMenusViewModel>> GetAppMenusAsync(Guid userGuid)
        {
            try
            {
                var response = await _appMenusDAL.GetAppMenusAsync(userGuid);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
