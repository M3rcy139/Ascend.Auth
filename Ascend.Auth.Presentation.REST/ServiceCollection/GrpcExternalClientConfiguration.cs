using Ascend.Auth.Infrastructure.Options;
using Ascend.Person.Client;
using Ascend.Common.Configuration.GRPC.Options;

namespace Ascend.Auth.Presentation.REST.ServiceCollection;

public static class GrpcExternalClientConfiguration
{
    public static IServiceCollection AddExternalClients(
        this IServiceCollection services, IConfiguration configuration)
    {
        var servicesOptions = configuration.GetSection(GrpcServiceOptions.Section).Get<GrpcServiceOptions>();
        
        if (servicesOptions == null || string.IsNullOrEmpty(servicesOptions.PersonService))
        {
            throw new InvalidOperationException("Missing or invalid GrpcServices:PersonService configuration");
        }
        
        services.AddPersonClient(o => o.Uri = servicesOptions.PersonService);

        return services;
    }
}