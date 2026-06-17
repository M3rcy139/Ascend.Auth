using Ascend.Auth.Business.Options;
using Ascend.Auth.Infrastructure.Authentication;

namespace Ascend.Auth.Presentation.REST.ServiceCollection;

public static class OptionsConfiguration
{
    public static void AddOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
        services.Configure<RefreshTokenOptions>(configuration.GetSection(nameof(RefreshTokenOptions)));
    }
}