using API.Domain.Models.Core;

namespace API.Infrastructure.DAL.Interfaces
{
    public interface IDepartmentDAL
    {
        public Task<List<DropdownModel>> GetDropdown();
    }
}
