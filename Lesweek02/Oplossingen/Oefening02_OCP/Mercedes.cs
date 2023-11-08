namespace Oefening_02_02_OCP;
public class Mercedes : ICar
{
    public string Name => "Mercedes";

    public string GetMileage()
    {
        return "20M";
    }
}
