namespace Oefening_01_03_Interfaces;
public class Dog : Animal, IMakeSound
{
    public void MakeSound()
    {
        Console.WriteLine($"Waf waf, ik ben {Age} jaar");
    }
}

