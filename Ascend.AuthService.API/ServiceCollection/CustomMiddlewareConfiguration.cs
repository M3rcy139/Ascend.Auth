using Ascend.AuthService.API.Middleware;

namespace Ascend.AuthService.API.ServiceCollection;

public static class CustomMiddlewareConfiguration
{
    public static IApplicationBuilder ConfigureCustomMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        app.UseMiddleware<DbTransactionMiddleware>();
        
        return app;
    }
}