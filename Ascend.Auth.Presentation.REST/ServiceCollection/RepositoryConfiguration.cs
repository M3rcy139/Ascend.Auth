using Ascend.Auth.DataAccess.Interfaces;
using Ascend.Auth.DataAccess.Repositories;

namespace Ascend.Auth.Presentation.REST.ServiceCollection;

public static class RepositoryConfiguration
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        //services.AddScoped<IContactDetailRepository, ContactDetailRepository>();
    }
}