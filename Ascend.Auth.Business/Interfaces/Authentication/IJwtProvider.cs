using Ascend.Auth.Domain.Models;

namespace Ascend.Auth.Business.Interfaces.Authentication;

public interface IJwtProvider
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken();
}