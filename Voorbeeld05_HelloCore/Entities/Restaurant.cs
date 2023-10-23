namespace Voorbeeld05_HelloCore.Entities;

public enum CuisineType
{
    None,
    French,
    Italian,
    Japanese
}

public class Restaurant
{
    public int Id { get; set; }
    public string Name { get; set; }
    public CuisineType CuisineType { get; set; }
}
