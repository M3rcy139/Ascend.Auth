using Ascend.Auth.Business.Interfaces;
using Ascend.Auth.Presentation.REST.Seeding;

namespace Ascend.Auth.Presentation.REST.ServiceCollection;

public static class SeederConfiguration
{
    public static void AddSeeders(this IServiceCollection services)
    {
        services.AddScoped<IDataSeeder, AuthDataSeeder>();
    }
}
