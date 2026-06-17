using Ascend.Auth.Domain.Models;

namespace Ascend.Auth.DataAccess.Interfaces;

public interface IRefreshTokenRepository
{
    Task AddAsync(RefreshToken refreshToken);
    Task<RefreshToken?> GetByTokenAsync(string token);
}
