using Ascend.Auth.Business.Interfaces;
using Ascend.Auth.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Ascend.Auth.Presentation.REST.ServiceCollection;

public static class AppExtensions
{
    public static async Task InitializeDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<AscendAuthDbContext>();
        await context.Database.MigrateAsync();

        var seeder = services.GetRequiredService<IDataSeeder>();
        await seeder.SeedAsync();
    }
}
