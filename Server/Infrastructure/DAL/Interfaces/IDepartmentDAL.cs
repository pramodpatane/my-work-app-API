using Server.Domain.Models.Core;

namespace Server.Infrastructure.DAL.Interfaces
{
    public interface IDepartmentDAL
    {
        public Task<List<DropdownModel>> GetDropdown();
    }
}
