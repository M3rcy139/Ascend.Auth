using Ascend.Auth.Presentation.REST.Middleware;

namespace Ascend.Auth.Presentation.REST.ServiceCollection;

public static class CustomMiddlewareConfiguration
{
    public static IApplicationBuilder ConfigureCustomMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();

        return app;
    }
}
