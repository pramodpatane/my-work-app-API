using Server.Application.Interfaces;
using Server.Domain.Models.Core;
using Server.Infrastructure.DAL.Interfaces;

namespace Server.Application.Services.Core
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
