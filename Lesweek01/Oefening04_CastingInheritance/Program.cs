using Oefening_01_04_CastingInheritance;

var buildings = new List<Building>
            {
                new Restaurant
                {
                    City = "Gent",
                    CuisineType = CuisineType.French,
                    NumberOfTables = 10,
                    Street = "Sint-Baafsplein 5"
                },
                new Shop {City = "Antwerpen", Street = "Meir 32", HasWebshop = true},
                new Pool {City = "Antwerpen", Street = "Desguinlei 17", WaterTemperature = 28.5},
                new Shop {City = "Brussel", Street = "Nieuwstraat 3"},
            };
foreach (var building in buildings)
{
    Console.WriteLine($"Het adres van het gebouw is: {building.Street}, {building.City}");
    var pool = building as Pool;
    if (pool != null)
    {
        Console.WriteLine($"De temperatuur van het water is: {pool.WaterTemperature} ");
    }
    var restaurant = building as Restaurant;
    if (restaurant != null)
    {
        Console.WriteLine($"Het restaurant heeft: {restaurant.NumberOfTables} tafels ");
        Console.WriteLine($"Het keuken type is: {restaurant.CuisineType} ");
    }
    var shop = building as Shop;
    if (shop != null)
    {
        var webshop = shop.HasWebshop ? "een" : "geen";
        Console.WriteLine($"De winkel heeft {webshop} webshop");
    }
    Console.WriteLine();
}


