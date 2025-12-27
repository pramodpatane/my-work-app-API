using API.Models.Core;
using API.Models.Feature;

namespace API.DAL.Interfaces
{
    public interface IEmployeeDAL
    {
        public Task<List<EmployeeViewModel>> GetEmployeesData(FilterData filterData);
    }
}
