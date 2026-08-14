using Server.Domain.Models.Core;

namespace Server.Application.Interfaces
{
    public interface IDepartmentService
    {
        public Task<List<DropdownModel>> GetDropdown();
    }
}
