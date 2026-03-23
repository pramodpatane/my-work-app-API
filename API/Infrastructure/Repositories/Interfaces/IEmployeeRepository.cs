using API.Domain.Models.Core;
using API.Domain.Models.Feature;

namespace API.Infrastructure.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task<List<Employee>> GetEmployees(FilterData model);

        public Task<Employee> GetEmployeeById(int id);

        public Task<int> CreateEmployee(Employee employee);

        public Task<int> UpdateEmployee(Employee employee);

        public Task<string> DeleteEmployeeById(int id);
    }
}
