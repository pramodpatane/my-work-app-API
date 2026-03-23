using API.Application.Interfaces;
using API.Domain.Models.Core;
using API.Infrastructure.DAL.Interfaces;

namespace API.Application.Services.Core
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
