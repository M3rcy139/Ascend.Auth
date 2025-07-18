using Ascend.AuthService.Business.DTOs.Requests;
using Ascend.AuthService.Domain.Models;

namespace Ascend.AuthService.Business.Interfaces;

public interface IUserService
{
    Task Register(RegisterUserRequest request);
    Task<string> Login(LoginUserRequest request);
    Task<User> GetUserByIdAsync(Guid userId);
}