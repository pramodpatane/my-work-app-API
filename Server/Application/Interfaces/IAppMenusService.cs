using Server.Domain.Models.Core;

namespace Server.Application.Interfaces
{
    public interface IAppMenusService
    {
        public Task<List<AuthMenusViewModel>> GetAppMenusAsync(Guid userGuid);
    }
}
