using API.Application.DTOs;
using API.Application.Interfaces;
using API.Domain.Entities.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Core
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : BaseApiController
    {
        private readonly IUsersService _usersService;
        private readonly IEmailService _emailService;
        public UsersController(IUsersService usersService, IEmailService emailService)
        {
            _usersService = usersService;
            _emailService = emailService;
        }

        [HttpGet]
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

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> InsertUser ([FromBody] UsersDto users)
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

        [HttpGet("GetById/{RecordId}")]
        public async Task<IActionResult> GetById(Guid RecordId)
        {
            try
            {
                var response = await _usersService.GetById(RecordId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
