using API.Models.Core;
using API.Models.Feature;

namespace API.Services.Interfaces
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
