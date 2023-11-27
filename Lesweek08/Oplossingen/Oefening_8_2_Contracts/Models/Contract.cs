namespace Oefening_8_2_EFContracts.Models;

public class Contract
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public TypeEnum Type { get; set; }
    public StateEnum State { get; set; }
}
