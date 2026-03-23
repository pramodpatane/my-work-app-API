using API.Domain.Models.Core;

namespace API.Application.Interfaces
{
    public interface IJWTTokenService
    {
        RefreshTokenModel GenerateToken(LoginResponse user);
    }
}
