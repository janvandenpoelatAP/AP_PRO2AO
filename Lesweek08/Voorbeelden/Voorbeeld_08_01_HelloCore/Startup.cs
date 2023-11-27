using HelloCore.Entities;
using Microsoft.EntityFrameworkCore;
using Voorbeeld_08_01_HelloCore.Services;

namespace Voorbeeld_08_01_HelloCore;
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IGreeter, Greeter>();
        services.AddScoped<IRestaurantData, RestaurantDataSQL>();
        services.AddControllers();
        services.AddSwaggerGen();
        var connection = "server = localhost; database = restaurant-db; user=root; password = abc123";
        //var connection = "server = localhost; port = 3310; database = samurai-db; user=databanken; password=databanken";
        services.AddDbContext<HelloCoreDbContext>(x => x.UseMySql(connection, ServerVersion.AutoDetect(connection)));
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

