namespace Voorbeeld01_HelloCore;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IGreeter, Greeter>();
        services.AddControllers();
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IGreeter greeter)
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

        // app.UseWelcomePage();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            // endpoints.MapGet("/", async context =>
            //{
            // throw new Exception();
            // await context.Response.WriteAsync(greeter.GetGreeting());
            endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            //});
        });
    }
}

