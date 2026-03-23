using API.Domain.Models.Core;

namespace API.Application.Interfaces
{
    public interface IOTPService
    {
        string GenerateOtp();

        Task<Response> SaveOtp(string email, string otp);

        Task<bool> VerifyOtp(string email, string otp);
    }
}
