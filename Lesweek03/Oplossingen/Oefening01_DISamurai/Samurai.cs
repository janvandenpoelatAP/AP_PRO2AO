namespace Oefening01_DISamurai;
public class Samurai
{
    private readonly IWeapon[] weapons;

    public Samurai(IWeapon[] weapons)
    {
        this.weapons = weapons;
    }

    public void Attack(string target)
    {
        foreach (var weapon in weapons)
        {
            weapon.Hit(target);
        }
    }
}
