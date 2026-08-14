using Server.Domain.Models.Core;

namespace Server.Application.Interfaces
{
    public interface IUserRolesService
    {
        Task<List<DropdownModel>> GetDropdown();
    }
}
