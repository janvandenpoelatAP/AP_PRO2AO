namespace Oefening01_DISamurai;
public class Gun : IWeapon
{
    private readonly ITrigger trigger;
    
	public Gun(ITrigger trigger)
    {
        this.trigger = trigger;
    }

    public void Hit(string target)
    {
        Console.WriteLine($"Shooting{target}");
        trigger.Pull();
    }
}
