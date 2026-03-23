using API.Domain.Models.Core;

namespace API.Application.Interfaces
{
    public interface IDepartmentService
    {
        public Task<List<DropdownModel>> GetDropdown();
    }
}
