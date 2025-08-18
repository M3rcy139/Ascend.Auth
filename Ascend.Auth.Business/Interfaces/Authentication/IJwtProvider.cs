using Ascend.Auth.Domain.Models;

namespace Ascend.Auth.Business.Interfaces.Authentication;

public interface IJwtProvider
{
    string Generate(User user);
}