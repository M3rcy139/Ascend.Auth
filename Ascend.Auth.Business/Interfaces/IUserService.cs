using Ascend.Auth.Business.DTOs.Requests;
using Ascend.Auth.Domain.Models;

namespace Ascend.Auth.Business.Interfaces;

public interface IUserService
{
    Task Register(RegisterUserRequest request);
    Task<string> Login(LoginUserRequest request);
    Task<User> GetUserByIdAsync(Guid userId);
}