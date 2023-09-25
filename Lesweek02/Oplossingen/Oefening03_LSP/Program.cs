using Oefening03_LSP;

List<Fruit> fruits = new List<Fruit>()
{
    new Apple(),
    new Orange()
};
foreach (var fruit  in fruits)
{
    Console.WriteLine(fruit.GetColor());
}
