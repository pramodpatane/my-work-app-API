using API.DAL.Interfaces;
using API.Models.Core;

namespace API.Services.Core
{
    public class UserRolesService : IUserRolesService
    {
        private readonly IUserRolesDAL _userRolesDAL;
        public UserRolesService(IUserRolesDAL userRolesDAL)
        {
            _userRolesDAL = userRolesDAL;
        }

        public async Task<List<DropdownModel>> GetDropdown()
        {
            try
            {
                var dropdown = await _userRolesDAL.GetDropdown();
                return dropdown;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
