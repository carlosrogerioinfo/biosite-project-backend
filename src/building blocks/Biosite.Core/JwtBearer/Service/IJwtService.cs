using Biosite.Core.Commands.Response;

namespace Biosite.Core.JwtBearerToken.Service
{
    public interface IJwtService
    {
        string GenerateToken(UserResponse user);
    }
}
