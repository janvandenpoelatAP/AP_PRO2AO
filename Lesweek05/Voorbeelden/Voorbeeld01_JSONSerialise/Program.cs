using System.Text.Json;

Persoon persoon = new Persoon
{
    Naam = "Alice",
    Leeftijd = 30
};
string json = JsonSerializer.Serialize(persoon);
Console.WriteLine(json);

class Persoon
{
    public string Naam { get; set; }
    public int Leeftijd { get; set; }
}
