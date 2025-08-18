using Ascend.Auth.Infrastructure.Options;
using Ascend.Client;

namespace Ascend.Auth.Presentation.REST.ServiceCollection;

public static class GrpcExternalClientConfiguration
{
    public static IServiceCollection AddExternalClients(
        this IServiceCollection services, IConfiguration configuration)
    {
        var servicesOptions = configuration.GetSection(GrpcServiceOptions.Section).Get<GrpcServiceOptions>();
        
        services.AddPersonClient(o => o.Uri = servicesOptions.PersonService);

        return services;
    }
}