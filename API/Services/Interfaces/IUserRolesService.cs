using API.Models.Core;

namespace API.Services.Core
{
    public interface IUserRolesService
    {
        Task<List<DropdownModel>> GetDropdown();
    }
}
