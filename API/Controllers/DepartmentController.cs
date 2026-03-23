using API.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [Route("GetDropdown")]
        public async Task<IActionResult> GetDropdown()
        {
            try
            {
                var response = await _departmentService.GetDropdown();
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
