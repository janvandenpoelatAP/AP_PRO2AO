using System.Text.Json;

string json = @"{""Naam"":""Alice"",""Leeftijd"":30}";

Persoon persoon = JsonSerializer.Deserialize<Persoon>(json);
Console.WriteLine($"Naam: {persoon.Naam}, Leeftijd: {persoon.Leeftijd}");

class Persoon
{
    public string Naam { get; set; }
    public int Leeftijd { get; set; }
}
