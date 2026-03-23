using API.Application.DTOs;
using API.Application.Interfaces;
using API.Domain.Models.Core;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Core
{
    [ApiController]
    [Route("api/[controller]")]
    public class OTPController : ControllerBase
    {
        private readonly IOTPService _otpService;
        private readonly IEmailService _emailService;
        private readonly IAuthService _authService;

        public OTPController(IOTPService otpService,
                             IEmailService emailService,
                             IAuthService authService)
        {
            _otpService = otpService;
            _emailService = emailService;
            _authService = authService;
        }

        [HttpPost("SendOTP")]
        public async Task<IActionResult> SendOtp([FromBody] EmailRequestDTO emailRequest)
        {
            var response = new Response();
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new
                    {
                        Field = x.Key,
                        Message = x.Value.Errors.First().ErrorMessage
                    });
                response.IsSuccess = false;
                response.Message = "Validation failed";
            }
            var otp = _otpService.GenerateOtp();

            var saveOTPResponse = await _otpService.SaveOtp(emailRequest.ToEmail, otp);

            if (saveOTPResponse.IsSuccess)
            {
                emailRequest.Body = emailRequest.Body + " " + otp;
                await _emailService.SendEmailAsync(emailRequest);

                response.IsSuccess = true;
                response.Message = "OTP sent successfully";
            }
            return Ok(response);
        }

        [HttpPost("VerifyOTP")]
        public async Task<IActionResult> VerifyOtp([FromBody] OTPDTO model)
        {
            var isValid = await _otpService.VerifyOtp(model.Email, model.OTP);
            return Ok(isValid);
        }
    }
}
