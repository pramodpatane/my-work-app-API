using API.Models.Core;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Core
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService) {
            _usersService = usersService;
        }

        [HttpPost]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsersData(FilterData filterData)
        {
            try
            {
                var response = await _usersService.GetUsersData(filterData);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> InsertUser ([FromBody] Users users)
        {
            try
            {
                var response = await _usersService.InsertUser(users);
                return Ok(response);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        
    }
}
