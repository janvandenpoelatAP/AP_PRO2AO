using Oefening02_Casting;

var shapes = new object[4];
shapes[0] = new Dot(5, 7);
shapes[1] = new Square(5);
shapes[2] = new Circle(2);
shapes[3] = new Square(8);
foreach (var shape in shapes)
{
    var circle = shape as Circle;
    if (circle != null)
    {
        Console.WriteLine($"Cirkel: Oppervlakte: {circle.Area}");
    }
    var dot = shape as Dot;
    if (dot != null)
    {
        Console.WriteLine($"Punt: ({dot.X}, {dot.Y})");
    }
    var square = shape as Square;
    if (square != null)
    {
        Console.WriteLine($"Vierkant: Omtrek: {square.Perimeter}");
    }
}
