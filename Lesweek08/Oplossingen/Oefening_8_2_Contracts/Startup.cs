using Microsoft.EntityFrameworkCore;
using Oefening_8_2_EFContracts.Entities;
using Oefening_8_2_EFContracts.Services;

namespace Oefening_8_2_EFContracts;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IContractRepository, ContractRepositoryEF>();
        services.AddControllers();
        services.AddSwaggerGen();
        var connection = "server = localhost; database = contracts-db; user=root; password = abc123";
        services.AddDbContext<ContractDbContext>(x => x.UseMySql(connection, ServerVersion.AutoDetect(connection)));
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
