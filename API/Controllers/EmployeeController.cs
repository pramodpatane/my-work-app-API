using API.Models.Core;
using API.Models.Feature;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("GetEmployeesData")]
        public async Task<ActionResult> GetEmployeesData(FilterData model)
        {
            try
            {
                var result = await _employeeService.GetEmployeesData(model);
                return Ok(result);
            }
            catch (Exception ex) {
                throw ex;
            }            
        }

        [HttpGet]
        [Route("GetEmployeeById/{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _employeeService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex) {
                throw ex;
            }            
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create(Employee employee)
        {
            try
            {
                var userEmail = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
                employee.CreatedBy = userEmail;
                var result = await _employeeService.CreateEmployee(employee);
                return Ok(result);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        [HttpPost("Update")]
        public async Task<ActionResult> Update(Employee employee)
        {
            try
            {
                var userEmail = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
                employee.CreatedBy = userEmail;
                var result = await _employeeService.UpdateEmployee(employee);
                return Ok(result);
            }
            catch (Exception ex) {
                throw ex;
            }            
        }

        [HttpGet("Delete/{recordId}")]
        public async Task<ActionResult> Delete(Guid recordId)
        {
            try
            {
                Employee employee = new Employee();
                var userEmail = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
                employee.CreatedBy = userEmail;
                employee.RecordId = recordId;
                var result = await _employeeService.DeleteEmployeeById(employee);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
    }
}
