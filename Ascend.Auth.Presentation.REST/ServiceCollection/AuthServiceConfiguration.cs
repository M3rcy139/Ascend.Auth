using Ascend.Auth.Business.Interfaces.Authentication;
using Ascend.Auth.Client.Services;
using Ascend.Auth.Common.Factories;
using Ascend.Auth.Common.Interfaces;
using Ascend.Auth.Infrastructure.Authentication;
using Ascend.Common.Identity.Abstractions;

namespace Ascend.Auth.Presentation.REST.ServiceCollection;

public static class AuthServiceConfiguration
{
    public static void AddAuthServices(this IServiceCollection services)
    {
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<ICurrentUserFactory<ICurrentUser>, CurrentUserFactory>();
        services.AddScoped<ICurrentUserService, AscendCurrentUserService>();

    }
}