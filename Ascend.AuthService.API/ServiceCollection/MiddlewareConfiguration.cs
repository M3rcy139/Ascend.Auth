namespace Ascend.AuthService.API.ServiceCollection;

public static class MiddlewareConfiguration
{
    public static IApplicationBuilder ConfigureMiddleware(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DisplayRequestDuration();
            });
        }
        else
        {
            app.UseExceptionHandler("/error");
            app.UseHsts();
        }
            
        var serverAddresses = app.ServerFeatures.Get<Microsoft.AspNetCore.Hosting.Server.Features.IServerAddressesFeature>();
        bool isHttps = serverAddresses?.Addresses.Any(a => a.StartsWith("https://")) ?? false;
        
        if (isHttps)
        {
            app.UseHttpsRedirection();
        }
        
        app.UseRouting();
        //app.UseHttpMetrics();
        
        app.ConfigureCustomMiddleware();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            //endpoints.MapMetrics();
        });

        return app;
    }
}