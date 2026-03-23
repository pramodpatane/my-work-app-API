using API.Domain.Models.Core;

namespace API.Application.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(Login login);
    }
}
