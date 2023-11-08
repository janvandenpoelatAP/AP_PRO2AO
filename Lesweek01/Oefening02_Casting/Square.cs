namespace Oefening_01_02_Casting;
public class Square
{
    private int size;
    public Square(int size)
    {
        this.size = size;
    }
    public int Perimeter
    {
        get
        {
            return size * 4;
        }
    }
}
