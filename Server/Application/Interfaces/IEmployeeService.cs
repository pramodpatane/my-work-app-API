using Server.Domain.Entities.Core;
using Server.Domain.Models.Core;
using Server.Domain.Models.Feature;

namespace Server.Application.Interfaces
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
