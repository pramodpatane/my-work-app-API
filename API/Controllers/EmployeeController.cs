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

        [HttpPost("GetEmployees")]
        //[Route("GetEmployee")]
        public async Task<ActionResult> GetEmployees(FilterData model) {
            var result = await _employeeService.GetEmployees(model);
            return Ok(result);
        }

        [HttpPost("GetEmployeesData")]
        //[Route("GetEmployee")]
        public async Task<ActionResult> GetEmployeesData(FilterData model)
        {
            var result = await _employeeService.GetEmployeesData(model);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetEmployeeById/{id}")]
        public async Task<ActionResult> GetEmployeeById(int id)
        {
            var result = await _employeeService.GetEmployeeById(id);
            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateEmployees(Employee employee)
        {
            var result = await _employeeService.CreateEmployee(employee);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<ActionResult> UpdateEmployee(Employee employee)
        {
            var result = await _employeeService.UpdateEmployee(employee);
            return Ok(result);
        }

        [HttpPost("Delete/{id}")]
        public async Task<ActionResult> DeleteEmployeeById(int id)
        {
            var result = await _employeeService.DeleteEmployeeById(id);
            return Ok(result);
        }
    }
}
