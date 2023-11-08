using Voorbeeld_06_01_HelloCore.Services;

namespace Voorbeeld_06_01_HelloCore;
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IGreeter, Greeter>();
        services.AddScoped<IRestaurantData, RestaurantDataInMemory>();
        services.AddControllers();
        services.AddSwaggerGen();
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IGreeter greeter)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = String.Empty;
            });
        }
        else
        {
            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = context => context.Response.WriteAsync("OOPS")
            });
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}

