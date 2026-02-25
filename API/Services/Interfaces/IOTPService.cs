using API.Models.Core;

namespace API.Services.Interfaces
{
    public interface IOTPService
    {
        string GenerateOtp();

        Task<Response> SaveOtp(string email, string otp);

        Task<bool> VerifyOtp(string email, string otp);
    }
}
