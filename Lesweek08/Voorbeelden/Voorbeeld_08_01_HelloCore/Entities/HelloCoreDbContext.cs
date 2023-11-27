using Microsoft.EntityFrameworkCore;
using Voorbeeld_08_01_HelloCore.Entities;

namespace HelloCore.Entities
{
    public class HelloCoreDbContext : DbContext
    {
        public HelloCoreDbContext(DbContextOptions options) : base(options)
        {

        }
               
        public DbSet<Restaurant> Restaurants { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
        }
    }
}
 