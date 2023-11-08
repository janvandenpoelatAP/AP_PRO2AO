namespace Voorbeeld_03_02_DISamurai;
public class Dagger : IWeapon
{
    public void Hit(string target)
    {
        Console.WriteLine($"Stab {target}  to death");
    }
}