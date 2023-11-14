using Oefening_05_02_PersonsMVC.Services;

namespace Oefening_05_02_PersonsMVC;
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddScoped<IPersonData, InMemoryPersonData>();
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
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
            // endpoints.MapGet("/", async context =>
            //{
            // throw new Exception();
            // await context.Response.WriteAsync(greeter.GetGreeting());
            endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            //});
        });
    }
}

