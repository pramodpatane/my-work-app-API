using API.DAL.Interfaces;
using API.Models.Core;
using API.Models.Feature;
using API.Repositories.Interfaces;
using API.Services.Interfaces;

namespace API.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeDAL _employeeDAL;
        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeDAL employeeDAL) {
            _employeeRepository = employeeRepository;
            _employeeDAL = employeeDAL; 
        }

        public async Task<List<Employee>> GetEmployees(FilterData model)
        {
            try
            {
                var result = await _employeeRepository.GetEmployees(model);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<EmployeeViewModel>> GetEmployeesData(FilterData model)
        {
            try
            {
                var result = await _employeeDAL.GetEmployeesData(model);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            try
            {
                var response = await _employeeRepository.GetEmployeeById(id);
                return response;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<int> CreateEmployee(Employee employee)
        {
            try
            {
                var response = await _employeeRepository.CreateEmployee(employee);
                return response;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            try
            {
                var response = await _employeeRepository.UpdateEmployee(employee);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> DeleteEmployeeById(int id)
        {
            try
            {
                var response = await _employeeRepository.DeleteEmployeeById(id);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
