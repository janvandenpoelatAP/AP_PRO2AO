using System.Text.Json;

string json = @"
[
  {
    ""titel"": ""De Alchemist"",
    ""auteur"": ""Paulo Coelho"",
    ""jaar"": 1988,
    ""waardering"": 4.5
  },
  {
    ""titel"": ""Pride and Prejudice"",
    ""auteur"": ""Jane Austen"",
    ""jaar"": 1813,
    ""waardering"": 4.0
  },
  {
    ""titel"": ""To Kill a Mockingbird"",
    ""auteur"": ""Harper Lee"",
    ""jaar"": 1960,
    ""waardering"": 4.8
  }
]";

JsonSerializerOptions opties = new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
}; 

Boek[] boeken = JsonSerializer.Deserialize<Boek[]>(json, opties);

foreach (Boek boek in boeken)
{
    // rest
}


public class Boek
{
    public string Titel { get; set; }
    public string Auteur { get; set; }
    public int Jaar { get; set; }
    public float Waardering { get; set; }
}
