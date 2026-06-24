using System.Text.Json.Serialization;

namespace Ascend.Auth.Presentation.REST.ServiceCollection;

public static class ApiConfiguration
{
    public static void AddControllersAndSwagger(this IServiceCollection services)
    {
        services.AddControllers(options =>
            {
                options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

        services.AddRouting();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}