using Ascend.AuthService.Infrastructure.Authentication;

namespace Ascend.AuthService.API.ServiceCollection;

public static class OptionsConfiguration
{
    public static void AddOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
    }
}