using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Oefening_10_01_CourseManager.DbContexts;
using Oefening_10_01_CourseManager.Models;
using Oefening_10_01_CourseManager.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connection = builder.Configuration["ConnectionStrings:CourseManagerDBConnectionString"];
builder.Services.AddDbContext<CourseDbContext>(o => o.UseMySql(connection, ServerVersion.AutoDetect(connection)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}

var teachersEndpoints = app.MapGroup("/teachers");
var teachersEndPointsWithGuidId = teachersEndpoints.MapGroup("/{teacherid:guid}");
var coursesEndpoints = app.MapGroup("/courses");
var coursesEndPointsWithGuidId = coursesEndpoints.MapGroup("/{courseid:guid}");
var coursesFromTeacherEndpoints = app.MapGroup("/teachers/{teacherid}/courses");

teachersEndpoints.MapGet("", (
    CourseDbContext courseDbContext,
    IMapper mapper,
    string? name) =>
{
    return TypedResults.Ok(mapper.Map<IEnumerable<TeacherDto>>(
        courseDbContext.Teachers.Where(x => name == null || x.Name.Contains(name))));
});

teachersEndPointsWithGuidId.MapGet("", Results<NotFound, Ok<TeacherDto>> (
    CourseDbContext courseDbContext,
    IMapper mapper,
    Guid teacherId) =>
{
    var teacherEntity = courseDbContext.Teachers.FirstOrDefault(x => x.Id == teacherId);
    if (teacherEntity == null)
    {
        return TypedResults.NotFound();
    }
    return TypedResults.Ok(mapper.Map<TeacherDto>(teacherEntity));
}).WithName("GetTeacher");

teachersEndPointsWithGuidId.MapDelete("", Results<NotFound, NoContent> (
    CourseDbContext courseDbContext,
    Guid teacherId) =>
{
    var teachersEntity = courseDbContext.Teachers
         .FirstOrDefault(d => d.Id == teacherId);
    if (teachersEntity == null)
    {
        return TypedResults.NotFound();
    }
    courseDbContext.Teachers.Remove(teachersEntity);
    courseDbContext.SaveChanges();
    return TypedResults.NoContent();
});

coursesEndpoints.MapGet("", (
    CourseDbContext courseDbContext,
    IMapper mapper,
    string? name) =>
{
    List<Course> courses = courseDbContext.Courses.ToList();
    return TypedResults.Ok(mapper.Map<IEnumerable<CourseDto>>(
        courseDbContext.Courses.Where(x => name == null || x.Name.Contains(name))));


});

coursesEndpoints.MapPost("", CreatedAtRoute<Course> (
    CourseDbContext courseDbContext,
    IMapper mapper,
    CourseForCreationDto courseForCreationDto) =>
{
    var courseEntity = mapper.Map<Course>(courseForCreationDto);
    courseDbContext.Add(courseEntity);
    courseDbContext.SaveChanges();
    var courseToReturn = courseEntity;
    return TypedResults.CreatedAtRoute(courseToReturn, "GetCourse",
        new { courseId = courseToReturn.Id });
});

coursesEndPointsWithGuidId.MapPut("", Results<NotFound, NoContent> (
    CourseDbContext courseDbContext,
    IMapper mapper,
    Guid courseId,
    CourseForCreationDto courseForUpdateDto) =>
{
    var courseEntity = courseDbContext.Courses.FirstOrDefault(d => d.Id == courseId);
    if (courseEntity == null)
    {
        return TypedResults.NotFound();
    }
    courseEntity = mapper.Map<Course>(courseForUpdateDto);
    courseEntity.Id = courseId;
    courseDbContext.Update(courseEntity);
    courseDbContext.SaveChanges();
    return TypedResults.NoContent();
});

coursesEndPointsWithGuidId.MapDelete("", Results<NotFound, NoContent> (
    CourseDbContext courseDbContext,
    Guid courseId) =>
{
    var courseEntity = courseDbContext.Courses
         .FirstOrDefault(d => d.Id == courseId);
    if (courseEntity == null)
    {
        return TypedResults.NotFound();
    }
    courseDbContext.Courses.Remove(courseEntity);
    courseDbContext.SaveChanges();
    return TypedResults.NoContent();
});



teachersEndpoints.MapPost("", CreatedAtRoute<TeacherDto> (
    CourseDbContext courseDbContext,
    IMapper mapper,
    TeacherForCreationDto teacherForCreationDto) =>
{
    var teacherEntity = mapper.Map<Teacher>(teacherForCreationDto);
    courseDbContext.Add(teacherEntity);
    courseDbContext.SaveChanges();
    var teacherToReturn = mapper.Map<TeacherDto>(teacherEntity);
    return TypedResults.CreatedAtRoute(teacherToReturn, "GetTeacher",
        new { teacherId = teacherToReturn.Id });
});

coursesFromTeacherEndpoints.MapGet("", (
    CourseDbContext courseDbContext,
    IMapper mapper,
    Guid teacherId) =>
{
    return mapper.Map<IEnumerable<CourseDto>>(courseDbContext.Teachers
       .Include(x => x.Courses)
       .FirstOrDefault(x => x.Id == teacherId)?.Courses);
}).WithName("GetCourse"); ;

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<CourseDbContext>();
    context.Database.EnsureDeleted();
    context.Database.Migrate();
}

app.Run();

