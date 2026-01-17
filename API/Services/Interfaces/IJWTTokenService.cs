using API.Models.Core;

namespace API.Services.Interfaces
{
    public interface IJWTTokenService
    {
        RefreshTokenModel GenerateToken(LoginResponse user);
    }
}
