using Ascend.AuthService.GrpcService.Interceptors;

namespace Ascend.Auth.Presentation.REST.ServiceCollection;

public static class GrpServiceConfiguration
{
    public static void AddGrpcServices(this IServiceCollection services)
    {
        services.AddGrpc(options =>
        {
            options.Interceptors.Add<GrpcAuthInterceptor>();
        });
    }
}