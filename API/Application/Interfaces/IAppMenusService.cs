using API.Domain.Models.Core;

namespace API.Application.Interfaces
{
    public interface IAppMenusService
    {
        public Task<List<AuthMenusViewModel>> GetAppMenusAsync(Guid userGuid);
    }
}
