namespace Ascend.Auth.Presentation.REST.ServiceCollection;

public static class CorsConfiguration
{
    private const string PolicyName = "AllowFrontend";

    public static void AddCorsServices(this IServiceCollection services, IConfiguration configuration)
    {
        var origins = configuration.GetSection("CorsOptions:AllowedOrigins").Get<string[]>()
                      ?? ["http://localhost:5173", "http://localhost:3000", "http://127.0.0.1:3000", "http://127.0.0.1:5173"];

        services.AddCors(options =>
        {
            options.AddPolicy(PolicyName, policy =>
            {
                policy.WithOrigins(origins)
                      .AllowCredentials()
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });
    }

    public static IApplicationBuilder UseCorsFrontend(this IApplicationBuilder app) =>
        app.UseCors(PolicyName);
}