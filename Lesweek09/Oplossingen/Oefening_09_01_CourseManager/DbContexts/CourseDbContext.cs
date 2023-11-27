using Oefening_09_01_CourseManager.Entities;
using Microsoft.EntityFrameworkCore;

namespace Oefening_09_01_CourseManager.DbContexts;
public class CourseDbContext : DbContext
{
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Teacher> Teachers { get; set; } = null!;


    public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.Entity<Course>().HasData(
            new(Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "IT Organisatie"),
            new(Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "WPL Case"),
            new(Guid.Parse("c19099ed-94db-44ba-885b-0ad7205d5e40"), "API Ontwikkeling"),
            new(Guid.Parse("0c4dc798-b38b-4a1c-905c-a9e76dbef17b"), "Testing & Security"));

        _ = modelBuilder.Entity<Teacher>().HasData(
           new(Guid.Parse("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"),
            "Dimitri Sturm"),
           new(Guid.Parse("fe462ec7-b30c-4987-8a8e-5f7dbd8e0cfa"),
            "Jan Van den Poel"),
           new(Guid.Parse("b512d7cf-b331-4b54-8dae-d1228d128e8d"),
           "Sven Charleer"));

        _ = modelBuilder
            .Entity<Teacher>()
            .HasMany(d => d.Courses)
            .WithMany(i => i.Teachers)
            .UsingEntity(e => e.HasData(
                new { TeachersId = Guid.Parse("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"), CoursesId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35") },
                new { TeachersId = Guid.Parse("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"), CoursesId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96") },
                new { TeachersId = Guid.Parse("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"), CoursesId = Guid.Parse("c19099ed-94db-44ba-885b-0ad7205d5e40") },
                new { TeachersId = Guid.Parse("fe462ec7-b30c-4987-8a8e-5f7dbd8e0cfa"), CoursesId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35") },
                new { TeachersId = Guid.Parse("fe462ec7-b30c-4987-8a8e-5f7dbd8e0cfa"), CoursesId = Guid.Parse("c19099ed-94db-44ba-885b-0ad7205d5e40") },
                new { TeachersId = Guid.Parse("fe462ec7-b30c-4987-8a8e-5f7dbd8e0cfa"), CoursesId = Guid.Parse("0c4dc798-b38b-4a1c-905c-a9e76dbef17b") },
                new { TeachersId = Guid.Parse("b512d7cf-b331-4b54-8dae-d1228d128e8d"), CoursesId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96") }
                ));

        base.OnModelCreating(modelBuilder);
    }
}
