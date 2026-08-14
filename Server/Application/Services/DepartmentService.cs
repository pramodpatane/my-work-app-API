using Server.Application.Interfaces;
using Server.Domain.Models.Core;
using Server.Infrastructure.DAL.Interfaces;

namespace Server.Application.Services
{
    public class DepartmentService: IDepartmentService
    {
        private readonly IDepartmentDAL _departmentDAL;
        public DepartmentService(IDepartmentDAL departmentDAL) 
        {
            _departmentDAL = departmentDAL;
        }

        public async Task<List<DropdownModel>> GetDropdown()
        {
            try
            {
                var dropdown = await _departmentDAL.GetDropdown();
                return dropdown;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
