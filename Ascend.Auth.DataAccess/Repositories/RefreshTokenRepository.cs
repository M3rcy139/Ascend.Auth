using Ascend.Auth.DataAccess.Interfaces;
using Ascend.Auth.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Ascend.Auth.DataAccess.Repositories;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly AscendAuthDbContext _context;
    public RefreshTokenRepository(AscendAuthDbContext context) => _context = context;

    public async Task AddAsync(RefreshToken refreshToken)
    {
        await _context.RefreshTokens.AddAsync(refreshToken);
    }

    public async Task<RefreshToken?> GetByTokenAsync(string token)
    {
        return await _context.RefreshTokens
            .Include(rt => rt.User)
            .FirstOrDefaultAsync(rt => rt.Token == token);
    }
}
