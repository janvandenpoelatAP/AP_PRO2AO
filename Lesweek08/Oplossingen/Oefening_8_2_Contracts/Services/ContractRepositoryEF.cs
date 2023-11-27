using Oefening_8_2_EFContracts.Entities;
using Oefening_8_2_EFContracts.Models;

namespace Oefening_8_2_EFContracts.Services;

public class ContractRepositoryEF : IContractRepository
{
    private ContractDbContext context;

    public ContractRepositoryEF(ContractDbContext context)
    {
        this.context = context;
    }

    public IEnumerable<Contract> GetAll()
    {
        return context.Contracts;
    }
    public Contract Get(int id)
    {
        return context.Contracts.FirstOrDefault(x => x.Id == id);
    }
    public void Add(Contract contract)
    {
        context.Contracts.Add(contract);
        context.SaveChanges();
    }
    public void Delete(Contract contract)
    {
        var toDelete = Get(contract.Id);
        context.Contracts.Remove(toDelete);
        context.SaveChanges();
    }
    public void Update(Contract contract)
    {
        var oldContract = Get(contract.Id);
        //oldRestaurant.Name = restaurant.Name;
        //oldRestaurant.CuisineType = restaurant.CuisineType;
        context.SaveChanges();
    }
}
