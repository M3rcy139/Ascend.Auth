using Ascend.AuthService.Domain.Models;

namespace Ascend.AuthService.Business.Interfaces.Authentication;

public interface IJwtProvider
{
    string Generate(User user);
}