using API.Application.Interfaces;
using API.Domain.Models.Core;
using API.Infrastructure.DAL.Interfaces;

namespace API.Application.Services
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
