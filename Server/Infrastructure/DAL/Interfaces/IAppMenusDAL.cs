using Server.Domain.Models.Core;

namespace Server.Infrastructure.DAL.Interfaces
{
    public interface IAppMenusDAL
    {
        public Task<List<AuthMenusViewModel>> GetAppMenusAsync(Guid userGuid);
    }
}
