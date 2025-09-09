using Ascend.Auth.Business.Interfaces.Authentication;
using Ascend.Auth.Infrastructure.Authentication;

namespace Ascend.Auth.Presentation.REST.ServiceCollection;

public static class AuthServiceConfiguration
{
    public static void AddAuthServices(this IServiceCollection services)
    {
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
    }
}