using Ascend.AuthService.Business.Interfaces.Authentication;
using Ascend.AuthService.Infrastructure.Authentication;

namespace Ascend.AuthService.API.ServiceCollection;

public static class AuthServiceConfiguration
{
    public static void AddAuthServices(this IServiceCollection services)
    {
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
    }
}