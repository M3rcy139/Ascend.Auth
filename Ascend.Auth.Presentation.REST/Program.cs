using Ascend.Auth.Presentation.REST.ServiceCollection;
using Ascend.Common.Configuration.Logging;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

builder.Host.ConfigureLogging(configuration);

services.AddHttpContextAccessor();

services.AddDbServices(configuration);


services.AddControllersAndSwagger();

services.AddOptions(configuration);
services.AddExternalClients(configuration);
services.AddAuthServices();
services.AddServices();
services.AddRepositories();
services.AddAuthenticationConfiguration(configuration);
services.AddGrpcServices();

var app = builder.Build(); 

var logger = app.Services.GetRequiredService<ILogger<Program>>();

try
{
    logger.LogInformation("Application configuration complete. Initializing runtime.");
    
    app.ConfigureMiddleware(builder.Environment);
    
    logger.LogInformation("Application started successfully. Running...");
    app.Run();
}
catch (Exception ex)
{
    logger.LogCritical(ex, "The application terminated unexpectedly during runtime.");
    throw;
}

public partial class Program { }