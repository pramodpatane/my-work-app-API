using API.Models.Core;
using API.Models.Feature;

namespace API.Services.Interfaces
{
    public interface IEmployeeService
    {
        public Task<List<Employee>> GetEmployees(FilterData model);

        public Task<List<EmployeeViewModel>> GetEmployeesData(FilterData model);

        public Task<Employee> GetEmployeeById(int id);

        public Task<int> CreateEmployee(Employee employee);

        public Task<int> UpdateEmployee(Employee employee);

        public Task<string> DeleteEmployeeById(int id);
    }
}
