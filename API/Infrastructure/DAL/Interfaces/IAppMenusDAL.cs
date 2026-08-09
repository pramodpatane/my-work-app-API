using API.Domain.Models.Core;

namespace API.Infrastructure.DAL.Interfaces
{
    public interface IAppMenusDAL
    {
        public Task<List<AuthMenusViewModel>> GetAppMenusAsync(Guid userGuid);
    }
}
