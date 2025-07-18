using Ascend.AuthService.Business.Factories;
using Ascend.AuthService.Business.Interfaces;
using Ascend.AuthService.Business.Services;

namespace Ascend.AuthService.API.ServiceCollection;

public static class ServiceConfiguration
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        // services.AddScoped<IContactDetailService, ContactDetailService>();
        services.AddScoped<IUserFactory, UserFactory>();
    }
}