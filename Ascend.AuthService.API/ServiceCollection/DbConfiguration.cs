using Ascend.AuthService.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Ascend.AuthService.API.ServiceCollection;

public static class DbConfiguration
{
    public static void AddDbServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AscendAuthDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString(nameof(AscendAuthDbContext)),
                b => b.MigrationsAssembly("Ascend.AuthService.Migrations")));
    }
}