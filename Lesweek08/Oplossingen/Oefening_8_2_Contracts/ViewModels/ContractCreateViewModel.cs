using Oefening_8_2_EFContracts.Models;

namespace Oefening_8_2_EFContracts.ViewModels;

public class ContractCreateViewModel
{
    public string Code { get; set; }
    public string Description { get; set; }
    public TypeEnum Type { get; set; }
    public StateEnum State { get; set; }
}
