namespace Oefening_02_02_OCP;
public class Audi : ICar
{
    public string Name => "Audi";

    public string GetMileage()
    {
        return "10M";
    }
}
