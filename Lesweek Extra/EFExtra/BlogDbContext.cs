using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExtra;

public class BlogDbContext : DbContext
{
    string connection = "server=localhost; database=extra-db; user=root; password=abc123";
    public DbSet<Blog> Blogs {  get; set; }
    public DbSet<Post> Posts {  get; set; }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<>()
    //        .HasKey(x => new { x., x. });
    //    base.OnModelCreating(modelBuilder);
    //}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder
        .UseMySql(connection, ServerVersion.AutoDetect(connection))
        .LogTo(message => Debug.WriteLine(message))
        .EnableSensitiveDataLogging();
}
