using Ascend.Common.Configuration.REST.Extensions;

namespace Ascend.Auth.Presentation.REST.ServiceCollection;

public static class CustomMiddlewareConfiguration
{
    public static IApplicationBuilder ConfigureCustomMiddleware(this IApplicationBuilder app)
    {
        app.UseAscendExceptionHandling();

        return app;
    }
}
