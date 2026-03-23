using API.Domain.Models.Core;

namespace API.Application.Interfaces
{
    public interface IUserRolesService
    {
        Task<List<DropdownModel>> GetDropdown();
    }
}
