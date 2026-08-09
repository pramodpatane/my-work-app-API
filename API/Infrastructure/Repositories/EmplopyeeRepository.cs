using API.Domain.Entities.Core;
using API.Infrastructure.Contexts;
using API.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Repositories
{
    public class EmplopyeeRepository : IEmployeeRepository
    {
        private readonly MyContext _context;
        public EmplopyeeRepository(MyContext context)
        {
            _context = context;
        }

        // Get all employees
        public async Task<List<Employee>> GetEmployees(FilterData model)
        {
            var employees = await _context.Employees1
                .Where(e => e.IsActive == true)
                .OrderBy(e => e.Id)
                .Skip(model.Skip)
                .Take(model.Pagesize)
                .Select(e => new Employee
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    Salary = e.Salary,
                    DepartmentId = e.DepartmentId,
                    IsActive = e.IsActive,
                    CreatedDate = e.CreatedDate
                }).ToListAsync();

            return employees;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            try
            {
                var existing = await _context.Employees1
                                             .FirstOrDefaultAsync(e => e.Id == id);
                return existing == null ? null : existing;
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
                var existing = await _context.Employees1
                                     .FirstOrDefaultAsync(e => e.Email == employee.Email);
                if (existing != null)
                    return 0;

                employee.CreatedDate = DateTime.Now;
                await _context.Employees1.AddAsync(employee);
                await _context.SaveChangesAsync();
                return employee.Id;

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
                var existing = await _context.Employees1
                                             .FirstOrDefaultAsync(e => e.Id == employee.Id);

                if (existing == null)
                    return 0;

                // Update fields
                existing.FirstName = employee.FirstName;
                existing.LastName = employee.LastName;
                existing.Email = employee.Email;
                existing.Salary = employee.Salary;
                existing.DepartmentId = employee.DepartmentId;
                existing.UpdatedBy = employee.UpdatedBy;
                existing.UpdatedDate = DateTime.Now;

                await _context.SaveChangesAsync();

                return existing.Id;
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
                var employee = await _context.Employees1.FirstOrDefaultAsync(e => e.Id == id);

                if (employee == null)
                {
                    return "Employee not found";
                }

                employee.IsActive = false;
                employee.IsDeleted = true;
                //_context.Employees1.Remove(employee);
                await _context.SaveChangesAsync();

                return "Employee deleted successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
