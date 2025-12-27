using API.Models.Core;

namespace API.DAL.Interfaces
{
    public interface IUserRolesDAL
    {
        public Task<List<DropdownModel>> GetDropdown();
    }
}
