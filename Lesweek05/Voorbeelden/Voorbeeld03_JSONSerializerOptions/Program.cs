using System.Text.Json.Serialization;
using System.Text.Json;

JsonSerializerOptions opties = new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    Converters = { new JsonStringEnumConverter() }
};

// JSON-opties gebruiken bij serialisatie
string json = JsonSerializer.Serialize(new Person { Naam = "Alice", Gender = Gender.V, Leeftijd = 30 }, opties);
Console.WriteLine(json); // Geeft '{"naam":"Alice","leeftijd":30,"gender"="V"}' weer

enum Gender { M, V, X }

class Person
{
    public string Naam { get; set; }
    public int Leeftijd { get; set; }
    public Gender Gender { get; set; }
}
