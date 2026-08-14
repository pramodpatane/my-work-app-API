using Server.Application.Interfaces;
using Server.Controllers.Core;
using Server.Domain.Entities.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController: BaseApiController
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("GetData")]
        public async Task<ActionResult> GetEmployeesData([FromBody] FilterData model)
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
        [Route("GetById{id}")]
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

        [HttpPost("Insert")]
        public async Task<ActionResult> Create([FromBody] Employee employee)
        {
            try
            {
                employee.CreatedBy = UserEmail;
                var result = await _employeeService.CreateEmployee(employee);
                return Ok(result);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] Employee employee)
        {
            try
            {
                employee.UpdatedBy = UserEmail;
                    //User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
                var result = await _employeeService.UpdateEmployee(employee);
                return Ok(result);
            }
            catch (Exception ex) {
                throw ex;
            }            
        }

        [HttpDelete("Delete{recordId}")]
        public async Task<ActionResult> Delete(Guid recordId)
        {
            try
            {
                Employee employee = new Employee();
                employee.UpdatedBy = UserEmail;
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
