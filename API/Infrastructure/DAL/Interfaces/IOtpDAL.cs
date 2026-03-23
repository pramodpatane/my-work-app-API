using API.Domain.Models.Core;

namespace API.Infrastructure.DAL.Interfaces
{
    public interface IOtpDAL
    {
        Task<Response> SaveOtp(string email, string otp);

        Task<bool> VerifyOtp(string email, string otp);
    }
}
