using Ascend.AuthService.Domain.Models;

namespace Ascend.AuthService.DataAccess.Interfaces;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User?> GetUserByUserNameAsync(string userName);
    Task<User?> GetUserByEmailAsync(string email);
    Task<IEnumerable<User>> GetUsersByIdsAsync(IEnumerable<Guid> userIds);
    Task<User?> GetUserByIdAsync(Guid id);
    Task<bool> UserNameExistsAsync(string userName);
    Task<bool> UserEmailExistsAsync(string email);
    Task<bool> UserPhoneNumberExistsAsync(string phoneNumber);
}