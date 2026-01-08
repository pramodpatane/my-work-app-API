using API.Models.Core;

namespace API.DAL.Interfaces
{
    public interface IDepartmentDAL
    {
        public Task<List<DropdownModel>> GetDropdown();
    }
}
