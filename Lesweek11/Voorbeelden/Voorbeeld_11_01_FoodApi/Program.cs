using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Voorbeeld_11_01_FoodApi.Models;
using Voorbeeld_11_01_FoodApi.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Register the DbContext on the container, getting the connection string from appSettings
var connection = builder.Configuration["ConnectionStrings:DishesDBConnectionString"];
builder.Services.AddDbContext<DishesDbContext>(o => o.UseMySql(connection, ServerVersion.AutoDetect(connection)));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddProblemDetails();
builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler(configureApplicationBuilder =>
//    {
//        configureApplicationBuilder.Run(
//        async context =>
//        {
//            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
//            context.Response.ContentType = "text/html";
//            await context.Response.WriteAsync("An unexpected problem happened.");
//        });
//    });
//}
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}

var dishesEndpoints = app.MapGroup("/dishes").RequireAuthorization();
var dishWithGuidIdEndpoints = dishesEndpoints.MapGroup("/{dishId:guid}");
var ingredientsEndpoints = dishWithGuidIdEndpoints.MapGroup("/ingredients").RequireAuthorization();


//app.MapGet("/dishes", (DishesDbContext dishesDbContext,
//    IMapper mapper) =>
//{
//    return mapper.Map<IEnumerable<DishDto>>(dishesDbContext.Dishes);
//});
//app.MapGet("/dishes", (DishesDbContext dishesDbContext,

dishesEndpoints.MapGet("", Ok<IEnumerable<DishDto>> (DishesDbContext dishesDbContext, ClaimsPrincipal claimsPrincipal,
        IMapper mapper,
          //[FromQuery] string? name) =>
        ILogger<DishDto> logger,
        string? name) =>
{
    Console.WriteLine(claimsPrincipal.Identity?.IsAuthenticated);
    logger.LogInformation("Getting the dishes");
    return TypedResults.Ok(mapper.Map<IEnumerable<DishDto>>(
    dishesDbContext.Dishes.Where(x => name == null || x.Name.Contains(name))));
});

//app.MapGet("/dishes/{dishid:guid}", (DishesDbContext dishesDbContext,
dishWithGuidIdEndpoints.MapGet("", Results<NotFound, Ok<DishDto>> (DishesDbContext dishesDbContext,
     IMapper mapper,
     Guid dishId) =>
{
    //    return mapper.Map<DishDto>(dishesDbContext.Dishes.FirstOrDefault(x => x.Id == dishId));
    var dishEntity = dishesDbContext.Dishes.FirstOrDefault(x => x.Id == dishId);
    if (dishEntity == null)
    {
        return TypedResults.NotFound();
    }
    return TypedResults.Ok(mapper.Map<DishDto>(dishEntity));
}).WithName("GetDish");

dishesEndpoints.MapGet("/{dishName}", (DishesDbContext dishesDbContext,
    IMapper mapper,
    string dishName) =>
{
    return mapper.Map<DishDto>(dishesDbContext.Dishes.FirstOrDefault(x => x.Name == dishName));
});

ingredientsEndpoints.MapGet("", (DishesDbContext dishesDbContext,
    IMapper mapper,
    Guid dishId) =>
{
    return mapper.Map<IEnumerable<IngredientDto>>(dishesDbContext.Dishes
       .Include(x => x.Ingredients)
       .FirstOrDefault(x => x.Id == dishId)?.Ingredients);
});

dishesEndpoints.MapPost("", (DishesDbContext DishesDbContext,
     IMapper mapper,
     DishForCreationDto dishForCreationDto) =>
{
    var dishEntity = mapper.Map<Dish>(dishForCreationDto);
    DishesDbContext.Add(dishEntity);
    DishesDbContext.SaveChanges();
    var dishToReturn = mapper.Map<DishDto>(dishEntity);
    //    return TypedResults.Ok(dishToReturn);
    return TypedResults.CreatedAtRoute(dishToReturn, "GetDish", new { dishId = dishToReturn.Id });
});

dishWithGuidIdEndpoints.MapPut("", Results<NotFound, NoContent> (DishesDbContext dishesDbContext,
     IMapper mapper,
     Guid dishId,
     DishForUpdateDto dishForUpdateDto) =>
{
    var dishEntity = dishesDbContext.Dishes
         .FirstOrDefault(d => d.Id == dishId);
    if (dishEntity == null)
    {
        return TypedResults.NotFound();
    }
    mapper.Map(dishForUpdateDto, dishEntity);
    dishesDbContext.SaveChanges();
    return TypedResults.NoContent();
});

dishWithGuidIdEndpoints.MapDelete("", Results<NotFound, NoContent> (DishesDbContext dishesDbContext,
     Guid dishId) =>
{
    var dishEntity = dishesDbContext.Dishes
         .FirstOrDefault(d => d.Id == dishId);
    if (dishEntity == null)
    {
        return TypedResults.NotFound();
    }
    dishesDbContext.Dishes.Remove(dishEntity);
    dishesDbContext.SaveChanges();
    return TypedResults.NoContent();
});

// recreate & migrate the database on each run, for demo purposes
using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<DishesDbContext>();
    context.Database.EnsureDeleted();
    context.Database.Migrate();
}

app.Run();
