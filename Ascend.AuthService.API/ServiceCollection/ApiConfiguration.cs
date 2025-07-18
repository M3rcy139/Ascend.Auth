using System.Text.Json.Serialization;

namespace Ascend.AuthService.API.ServiceCollection;

public static class ApiConfiguration
{
    public static void AddControllersAndSwagger(this IServiceCollection services)
    {
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

        services.AddRouting();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}