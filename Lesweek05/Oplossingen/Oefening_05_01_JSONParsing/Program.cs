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

// Stap 1: JSON-gegevens inladen
List<Boek> boeken = JsonSerializer.Deserialize<List<Boek>>(json, opties);

// Stap 2: Bereken het gemiddelde van alle waarderingen van boeken
double gemiddeldeWaardering = boeken.Average(boek => boek.Waardering);
Console.WriteLine($"Gemiddelde waardering van alle boeken: {gemiddeldeWaardering:F2}");

// Stap 3: Identificeer het boek met de hoogste waardering
var bestGewaardeerdBoek = boeken.OrderByDescending(boek => boek.Waardering).First();
Console.WriteLine($"Het best gewaardeerde boek is \"{bestGewaardeerdBoek.Titel}\" door {bestGewaardeerdBoek.Auteur}");


public class Boek
{
    public string Titel { get; set; }
    public string Auteur { get; set; }
    public int Jaar { get; set; }
    public float Waardering { get; set; }
}
