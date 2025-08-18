using Ascend.Auth.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Ascend.Auth.Presentation.REST.ServiceCollection;

public static class DbConfiguration
{
    public static void AddDbServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AscendAuthDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString(nameof(AscendAuthDbContext)),
                b => b.MigrationsAssembly("Ascend.Auth.Migrations")));
    }
}