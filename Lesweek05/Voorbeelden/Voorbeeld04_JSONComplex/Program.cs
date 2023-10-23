using System.Text.Json;
using System.Text.Json.Serialization;

string json = @"
        {
            ""naam"": ""Alice"",
            ""leeftijd"": 30,
            ""adres"": {
                ""straat"": ""Tramezantlei"",
                ""gemeente"": ""Schoten"",
                ""zipcode"": ""12345""
            },
            ""hobbies"": [""Lezen"", ""Reizen""]
        }";

JsonSerializerOptions opties = new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
}; 

Persoon persoon = JsonSerializer.Deserialize<Persoon>(json, opties);

Console.WriteLine($"Naam: {persoon.Naam}, Leeftijd: {persoon.Leeftijd}");
Console.WriteLine($"Straat: {persoon.Adres.Straat}, Gemeente: {persoon.Adres.Gemeente}");
Console.WriteLine($"Hobbies: {string.Join(", ", persoon.Hobbies)}");

class Persoon
{
    public string Naam { get; set; }
    public int Leeftijd { get; set; }
    public Adres Adres { get; set; }
    public string[] Hobbies { get; set; }
}

class Adres
{
    public string Straat { get; set; }
    public string Gemeente { get; set; }
    public string Zipcode { get; set; }
}