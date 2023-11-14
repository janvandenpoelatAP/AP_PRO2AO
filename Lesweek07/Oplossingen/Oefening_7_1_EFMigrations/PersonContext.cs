using Microsoft.EntityFrameworkCore;

namespace Oefening_7_1_EFMigrations;
public class PersonContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Address> Address { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "server = localhost; database = efmigrations-db; user=root; password=abc123";
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
}
