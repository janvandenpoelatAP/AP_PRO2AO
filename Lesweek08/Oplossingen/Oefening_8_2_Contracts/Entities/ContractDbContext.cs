using Microsoft.EntityFrameworkCore;
using Oefening_8_2_EFContracts.Models;

namespace Oefening_8_2_EFContracts.Entities;

public class ContractDbContext : DbContext
{
	public ContractDbContext(DbContextOptions options) : base(options)
	{
	}
    public DbSet<Contract> Contracts { get; set; }  
}
