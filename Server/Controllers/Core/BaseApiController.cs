using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Server.Controllers.Core
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected Guid? UserGUID => Guid.Parse(FindClaim("UserGUID"));
        protected Guid? ClientGUID => Guid.Parse(FindClaim("ClientGUID"));
        protected string? UserName => FindClaim("UserName");
        protected string? UserEmail => User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;

        protected Guid? SessionGUID => Guid.Parse(FindClaim("jti"));

        private string? FindClaim(string claimName)
        {
            try
            {
                var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;

                var claim = claimsIdentity.FindFirst(claimName);

                if (claim == null)
                {
                    return null;
                }

                return claim.Value;
            }
            catch
            {
                return null;
            }

        }
    }
}
