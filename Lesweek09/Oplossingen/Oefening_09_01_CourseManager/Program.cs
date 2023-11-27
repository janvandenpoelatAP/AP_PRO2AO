using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Oefening_09_01_CourseManager.DbContexts;
using Oefening_09_01_CourseManager.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connection = builder.Configuration["ConnectionStrings:CourseManagerDBConnectionString"];
builder.Services.AddDbContext<CourseDbContext>(o => o.UseMySql(connection, ServerVersion.AutoDetect(connection)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGet("/teachers", (CourseDbContext courseDbContext, IMapper mapper) =>
{
    return mapper.Map<IEnumerable<TeacherDto>>(courseDbContext.Teachers);
});

app.MapGet("/teachers/{teacherid}/courses", (CourseDbContext courseDbContext,
    IMapper mapper,
    Guid teacherId) =>
{
    return mapper.Map<IEnumerable<CourseDto>>(courseDbContext.Teachers
       .Include(x => x.Courses)
       .FirstOrDefault(x => x.Id == teacherId)?.Courses);
});

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<CourseDbContext>();
    context.Database.EnsureDeleted();
    context.Database.Migrate();
}

app.Run();

