using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Oefening_11_01_CourseManager.DbContexts;
using Oefening_11_01_CourseManager.Models;
using Oefening_11_01_CourseManager.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connection = builder.Configuration["ConnectionStrings:CourseManagerDBConnectionString"];
builder.Services.AddDbContext<CourseDbContext>(o => o.UseMySql(connection, ServerVersion.AutoDetect(connection)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddProblemDetails();
builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}

// Teachers Endpoints

var teachersEndpoints = app.MapGroup("/teachers").RequireAuthorization();
var teachersEndPointsWithGuidId = teachersEndpoints.MapGroup("/{teacherid:guid}").RequireAuthorization();

teachersEndpoints.MapGet("", Ok<IEnumerable<TeacherDto>> (
    CourseDbContext courseDbContext,
    ILogger<TeacherDto> logger,
    IMapper mapper,
    string? name) =>
{
    logger.LogInformation("Retrieved teachers ");
    return TypedResults.Ok(mapper.Map<IEnumerable<TeacherDto>>(
        courseDbContext.Teachers.Where(x => name == null || x.Name.Contains(name))));
});

teachersEndPointsWithGuidId.MapGet("", Results<NotFound, Ok<TeacherDto>> (
    CourseDbContext courseDbContext,
    ILogger<TeacherDto> logger,
    IMapper mapper,
    Guid teacherId) =>
{
    logger.LogInformation("Retrieved teacher");
    var teacherEntity = courseDbContext.Teachers.FirstOrDefault(x => x.Id == teacherId);
    if (teacherEntity == null)
    {
        return TypedResults.NotFound();
    }
    return TypedResults.Ok(mapper.Map<TeacherDto>(teacherEntity));
}).WithName("GetTeacher");

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

teachersEndPointsWithGuidId.MapPut("", Results<NotFound, NoContent> (
    CourseDbContext courseDbContext,
    IMapper mapper,
    Guid teacherId,
    TeacherForUpdateDto teacherForUpdateDto) =>
{
    var teacherEntity = courseDbContext.Teachers.FirstOrDefault(d => d.Id == teacherId);
    if (teacherEntity == null)
    {
        return TypedResults.NotFound();
    }
    teacherEntity.Name = teacherForUpdateDto.Name;
    courseDbContext.SaveChanges();
    return TypedResults.NoContent();
});

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

// Courses Endpoints

var coursesEndpoints = app.MapGroup("/courses").RequireAuthorization();
var coursesEndPointsWithGuidId = coursesEndpoints.MapGroup("/{courseid:guid}").RequireAuthorization();

coursesEndpoints.MapGet("", Ok<IEnumerable<CourseDto>> (
    CourseDbContext courseDbContext,
    IMapper mapper,
    string? name) =>
{
    List<Course> courses = courseDbContext.Courses.ToList();
    return TypedResults.Ok(mapper.Map<IEnumerable<CourseDto>>(
        courseDbContext.Courses.Where(x => name == null || x.Name.Contains(name))));
});

coursesEndPointsWithGuidId.MapGet("", Results<NotFound, Ok<CourseDto>> (
    CourseDbContext courseDbContext,
    IMapper mapper,
    Guid courseId) =>
{
    var courseEntity = courseDbContext.Courses.FirstOrDefault(x => x.Id == courseId);
    if (courseEntity == null)
    {
        return TypedResults.NotFound();
    }
    return TypedResults.Ok(mapper.Map<CourseDto>(courseEntity));
}).WithName("GetCourse"); 

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
    CourseForUpdateDto courseForUpdateDto) =>
{
    var courseEntity = courseDbContext.Courses.FirstOrDefault(d => d.Id == courseId);
    if (courseEntity == null)
    {
        return TypedResults.NotFound();
    }
    courseEntity.Name = courseForUpdateDto.Name;
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

// CoursesFromTeachers Endpoints

var coursesFromTeacherEndpoints = app.MapGroup("/teachers/{teacherid}/courses").RequireAuthorization();

coursesFromTeacherEndpoints.MapGet("", (
    CourseDbContext courseDbContext,
    IMapper mapper,
    Guid teacherId) =>
{
    return mapper.Map<IEnumerable<CourseDto>>(courseDbContext.Teachers
       .Include(x => x.Courses)
       .FirstOrDefault(x => x.Id == teacherId)?.Courses);
}); ;

// Recontruct dB when starting up application

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<CourseDbContext>();
    context.Database.EnsureDeleted();
    context.Database.Migrate();
}

app.Run();

