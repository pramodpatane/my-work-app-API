using API.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Core
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AppMenusController : BaseApiController
    {
        private readonly IAppMenusService _appMenusService;
        public AppMenusController(IAppMenusService appMenusService)
        {
            _appMenusService = appMenusService;
        }

        [HttpGet]
        [Route("GetUserMenus{UserGuid}")]
        public async Task<IActionResult> GetUserMenus(Guid UserGuid)
        {
            try
            {
                var response = await _appMenusService.GetAppMenusAsync(UserGuid);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
