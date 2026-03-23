using API.Application.Interfaces;
using API.Domain.Models.Core;
using API.Infrastructure.DAL.Interfaces;

namespace API.Application.Services.Core
{
    public class OTPService : IOTPService
    {
        private readonly IOtpDAL _otpDAL;
        private readonly IAuthDAL _authDAL;
        public OTPService(IOtpDAL otpDAL, IAuthDAL authDAL  )
        {
            _otpDAL = otpDAL;
            _authDAL = authDAL;
        }
        public string GenerateOtp()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        public async Task<Response> SaveOtp(string email, string otp)
        {
            try
            {
                var response = new Response();
                var isUserExist = await _authDAL.IsUserExist(email);
                if(isUserExist != 0)
                {
                    var result = await _otpDAL.SaveOtp(email, otp);
                    response = result;
                }else
                {
                    response.IsSuccess = false;
                    response.Message = "This user is not exists!";
                }

                    return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> VerifyOtp(string email, string otp)
        {
            try
            {
                var response = await _otpDAL.VerifyOtp(email, otp);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
