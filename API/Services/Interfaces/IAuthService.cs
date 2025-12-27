using API.Models.Core;

namespace API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(Login login);
    }
}
