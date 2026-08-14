using Server.Domain.Entities.Core;
using Server.Domain.Models.Core;

namespace Server.Application.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(Login login);
    }
}
