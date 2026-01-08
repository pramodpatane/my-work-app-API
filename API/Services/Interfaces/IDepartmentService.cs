using API.Models.Core;

namespace API.Services.Interfaces
{
    public interface IDepartmentService
    {
        public Task<List<DropdownModel>> GetDropdown();
    }
}
