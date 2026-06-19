using Ascend.Auth.Business;
using Ascend.Auth.Business.Factories;
using Ascend.Auth.Business.Interfaces;
using Ascend.Common.Business.Behaviors;
using MediatR;

namespace Ascend.Auth.Presentation.REST.ServiceCollection;

public static class ServiceConfiguration
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(AssemblyMarker).Assembly));

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));

        services.AddScoped<IUserFactory, UserFactory>();
    }
}
