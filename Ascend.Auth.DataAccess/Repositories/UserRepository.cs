using Ascend.Auth.DataAccess.Interfaces;
using Ascend.Auth.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Ascend.Auth.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AscendAuthDbContext _context;
    public UserRepository(AscendAuthDbContext context) => _context = context;

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<User?> GetUserByUserNameAsync(string userName)
    {
        var user = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.UserName == userName);

        return user;
    }
    
    public async Task<User?> GetUserByEmailAsync(string email)
    {
        var user = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email);

        return user;
    }

    public async Task<IEnumerable<User>> GetUsersByIdsAsync(IEnumerable<Guid> userIds)
    {
        return await _context.Users
            .AsNoTracking()
            .Where(u => userIds.Contains(u.Id)).ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }
    
    public async Task<bool> UserNameExistsAsync(string userName)
    {
        return await _context.Users
            .AnyAsync(u => u.UserName == userName);
    }
    
    public async Task<bool> UserEmailExistsAsync(string email)
    {
        return await _context.Users
            .AnyAsync(u => u.Email == email);
    }
    
    public async Task<bool> UserPhoneNumberExistsAsync(string phoneNumber)
    {
        return await _context.ContactDetails
            .AnyAsync(cd => cd.PhoneNumber == phoneNumber);
    }
}