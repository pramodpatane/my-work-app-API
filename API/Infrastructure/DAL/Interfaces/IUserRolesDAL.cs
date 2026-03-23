using API.Domain.Models.Core;

namespace API.Infrastructure.DAL.Interfaces
{
    public interface IUserRolesDAL
    {
        public Task<List<DropdownModel>> GetDropdown();
    }
}
