using Ascend.Auth.Domain.Models;

namespace Ascend.Auth.DataAccess.Interfaces;

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