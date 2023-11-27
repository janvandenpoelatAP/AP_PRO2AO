using Oefening_08_02_EFContracts.Models;

namespace Oefening_08_02_EFContracts.Services;

public interface IContractRepository
{
    IEnumerable<Contract> GetAll();
    Contract Get(int id);
    void Add(Contract contract);
    void Delete(Contract contract);
    void Update(Contract contract);
}
