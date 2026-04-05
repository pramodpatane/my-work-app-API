using API.Application.Interfaces;
using API.Domain.Models.Core;
using API.Domain.Models.Feature;
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
        public string CreatedBy = ""; 
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            CreatedBy = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
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
        [Route("{id}")]
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

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            try
            {
                employee.CreatedBy = CreatedBy;
                var result = await _employeeService.CreateEmployee(employee);
                return Ok(result);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(Employee employee)
        {
            try
            {
                employee.UpdatedBy = CreatedBy;
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
                employee.UpdatedBy = CreatedBy;
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
