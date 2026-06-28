using API.Domain.Entities.Core;
using API.Domain.Models.Core;
using API.Domain.Models.Feature;

namespace API.Infrastructure.DAL.Interfaces
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
