namespace Oefening_04_01_ASPMVC;
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
       services.AddControllers();

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
            endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
        });
    }
}

