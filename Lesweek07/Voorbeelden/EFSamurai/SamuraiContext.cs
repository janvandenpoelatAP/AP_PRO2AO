using Microsoft.EntityFrameworkCore;

namespace Voorbeeld_07_01_EFSamurai;

public class SamuraiContext : DbContext
{
    public DbSet<Samurai> Samurais { get; set; }
    public DbSet<Quote> Quotes { get; set; }
    public DbSet<Battle> Battles { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "server = localhost; database = samurai-db; user=root; password=abc123";
        //var connectionString = "server = localhost; port = 3310; database = samurai-db; user=databanken; password=databanken";
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
}
