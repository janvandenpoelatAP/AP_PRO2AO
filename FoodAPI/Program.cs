using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Voorbeeld_09_1_FoodApi.Entities;
using Voorbeeld_09_1_FoodApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register the DbContext on the container, getting the connection string from appSettings
var connection = builder.Configuration["ConnectionStrings:DishesDBConnectionString"];
builder.Services.AddDbContext<DishesDbContext>(o => o.UseMySql(
    connection, ServerVersion.AutoDetect(connection)));

// Register AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.MapGet("/dishes", (DishesDbContext dishesDbContext,
    IMapper mapper) =>
{
    return mapper.Map<IEnumerable<DishDto>>(dishesDbContext.Dishes);
});

/*
app.MapGet("/dishes/{dishid:guid}", (DishesDbContext dishesDbContext,
    IMapper mapper,
    Guid dishId) =>
{
    return mapper.Map<DishDto>(dishesDbContext.Dishes.FirstOrDefault(x => x.Id == dishId));
});

app.MapGet("/dishes/{dishid}/ingredients", (DishesDbContext dishesDbContext,
    IMapper mapper,
    Guid dishId) =>
{
    return mapper.Map<IEnumerable<IngredientDto>>(dishesDbContext.Dishes
       .Include(x => x.Ingredients)
       .FirstOrDefault(x => x.Id == dishId)?.Ingredients);
});

app.MapGet("/dishes/{dishName}", (DishesDbContext dishesDbContext, string dishName) =>
{
    return dishesDbContext.Dishes.FirstOrDefault(x => x.Name == dishName);
});
*/

// recreate & migrate the database on each run, for demo purposes
using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<DishesDbContext>();
    context.Database.EnsureDeleted();
    context.Database.Migrate();
}
app.Run();

//internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}
