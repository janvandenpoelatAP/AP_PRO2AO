namespace Oefening01_DISamurai;
public class Sword : IWeapon
{
    public void Hit(string target)
    {
        Console.WriteLine($"Chopped {target} clean in half");
    }
}
