using API.Domain.Entities.Core;
using API.Domain.Models.Core;
using API.Domain.Models.Feature;

namespace API.Application.Interfaces
{
    public interface IEmployeeService
    {
        //public Task<List<Employee>> GetEmployees(FilterData model);

        public Task<GridResponse<EmployeeViewModel>> GetEmployeesData(FilterData model);

        public Task<EmployeeViewModel> GetById(Guid id);

        public Task<int> CreateEmployee(Employee employee);

        public Task<int> UpdateEmployee(Employee employee);

        public Task<Response> DeleteEmployeeById(Employee employee);
    }
}
