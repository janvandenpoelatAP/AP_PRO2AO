using Oefening_8_2_EFContracts.Models;

namespace Oefening_8_2_EFContracts.Services;

public interface IContractRepository
{
    IEnumerable<Contract> GetAll();
    Contract Get(int id);
    void Add(Contract contract);
    void Delete(Contract contract);
    void Update(Contract contract);
}
