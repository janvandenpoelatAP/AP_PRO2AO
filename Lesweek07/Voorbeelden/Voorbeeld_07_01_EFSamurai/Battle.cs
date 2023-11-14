namespace Voorbeeld_07_01_EFSamurai;

public class Battle
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<SamuraiBattle> SamuraiBattles { get; set; }
}
