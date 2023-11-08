namespace Oefening_01_02_Casting;
public class Circle
{
    private int radius;
    public Circle(int radius)
    {
        this.radius = radius;
    }
    public double Area
    {
        get { return radius * radius * Math.PI; }
    }
}
