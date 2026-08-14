using Server.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers.Core
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly IUserRolesService _userRolesService;
        public UserRolesController(IUserRolesService userRolesService)
        {
            _userRolesService = userRolesService;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetDropdown")]
        public async Task<IActionResult> GetDropdown()
        {
            try
            {
                var response = await _userRolesService.GetDropdown();
                return Ok(response);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}
