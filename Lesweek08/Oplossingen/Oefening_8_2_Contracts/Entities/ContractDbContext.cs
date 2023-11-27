using Microsoft.EntityFrameworkCore;
using Oefening_08_02_EFContracts.Models;

namespace Oefening_08_02_EFContracts.Entities;

public class ContractDbContext : DbContext
{
	public ContractDbContext(DbContextOptions options) : base(options)
	{
	}
    public DbSet<Contract> Contracts { get; set; }  
}
