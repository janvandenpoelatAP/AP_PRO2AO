using Microsoft.EntityFrameworkCore;
using Oefening_08_01_BlogEF.Services;
using Oefening_08_01_BlogEF.Entities;

namespace Oefening_08_01_BlogEF;

public class Startup
{
    private IConfiguration configuration;
    public Startup(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddControllers();
        services.AddSwaggerGen();
        var connection = configuration.GetConnectionString("BloggingDatabase");
        services.AddDbContext<BlogContext>(x => x.UseMySql(connection, ServerVersion.AutoDetect(connection)));
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
