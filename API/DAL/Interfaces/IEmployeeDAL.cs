using API.Models.Core;
using API.Models.Feature;

namespace API.DAL.Interfaces
{
    public interface IEmployeeDAL
    {
        public Task<GridResponse<EmployeeViewModel>> GetEmployeesData(FilterData filterData);

        public Task<EmployeeViewModel> GetById(Guid id);

        public Task<int> Create(Employee model);
        public Task<int> Update(Employee model);

        public Task<Response> Delete(Employee model);
    }
}
