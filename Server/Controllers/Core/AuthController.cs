using Server.Application.Interfaces;
using Server.Domain.Entities.Core;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers.Core
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
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
    }
}
