using API.Models.Core;
using API.Services.Core;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Core
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public readonly IUserRolesService _userRolesService;
        public AuthController(IAuthService authService, IUserRolesService userRolesService)
        {
            _authService = authService;
            _userRolesService = userRolesService;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            try
            {
                var response = await _authService.Login(login);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetUserDropdown")]
        public async Task<IActionResult> GetDropdown()
        {
            try
            {
                var response = await _userRolesService.GetDropdown();
                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
