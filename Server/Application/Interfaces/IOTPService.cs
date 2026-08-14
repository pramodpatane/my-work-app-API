using Server.Domain.Entities.Core;

namespace Server.Application.Interfaces
{
    public interface IOTPService
    {
        string GenerateOtp();

        Task<Response> SaveOtp(string email, string otp);

        Task<bool> VerifyOtp(string email, string otp);
    }
}
