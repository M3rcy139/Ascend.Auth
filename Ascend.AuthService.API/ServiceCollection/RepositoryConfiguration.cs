using Ascend.AuthService.DataAccess.Interfaces;
using Ascend.AuthService.DataAccess.Repositories;

namespace Ascend.AuthService.API.ServiceCollection;

public static class RepositoryConfiguration
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        //services.AddScoped<IContactDetailRepository, ContactDetailRepository>();
    }
}