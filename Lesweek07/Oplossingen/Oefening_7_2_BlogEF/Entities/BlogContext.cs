using Microsoft.EntityFrameworkCore;

namespace Oefening_7_2_BlogEF.Entities;
public class BlogContext : DbContext
{
    public BlogContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Post> Posts { get; set; }
}
