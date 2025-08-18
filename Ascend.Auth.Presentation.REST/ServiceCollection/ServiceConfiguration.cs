using Ascend.Auth.Business.Factories;
using Ascend.Auth.Business.Interfaces;
using Ascend.Auth.Business.Services;

namespace Ascend.Auth.Presentation.REST.ServiceCollection;

public static class ServiceConfiguration
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        // services.AddScoped<IContactDetailService, ContactDetailService>();
        services.AddScoped<IUserFactory, UserFactory>();
    }
}