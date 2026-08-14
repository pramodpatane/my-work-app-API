using Server.Domain.Models.Core;

namespace Server.Application.Interfaces
{
    public interface IJWTTokenService
    {
        RefreshTokenModel GenerateToken(LoginResponse user);
    }
}
