using Server.Application.Interfaces;
using Server.Domain.Entities.Core;
using Server.Domain.Models.Core;
using Server.Domain.Models.Feature;
using Server.Infrastructure.DAL.Interfaces;

namespace Server.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeDAL _employeeDAL;
        public EmployeeService(IEmployeeDAL employeeDAL)
        {
            _employeeDAL = employeeDAL;
        }

        //public async Task<List<Employee>> GetEmployees(FilterData model)
        //{
        //    try
        //    {
        //        var result = await _employeeRepository.GetEmployees(model);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public async Task<GridResponse<EmployeeViewModel>> GetEmployeesData(FilterData model)
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

        public async Task<EmployeeViewModel> GetById(Guid id)
        {
            try
            {
                var response = await _employeeDAL.GetById(id);
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
                var response = await _employeeDAL.Create(employee);
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
                var response = await _employeeDAL.Update(employee);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Response> DeleteEmployeeById(Employee employee)
        {
            try
            {
                var response = await _employeeDAL.Delete(employee);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
