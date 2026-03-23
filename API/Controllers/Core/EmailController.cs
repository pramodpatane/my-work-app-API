using API.Application.Interfaces;
using API.Domain.Models.Core;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Core
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            this._emailService = emailService;
        }

        [HttpGet("GetEmailConfiguration/{formCode}")]
        public async Task<Response> GetEmailConfiguration(string formCode)
        {
            try
            {
                var response = new Response();
                response = await _emailService.GetEmailConfiguration(formCode);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
