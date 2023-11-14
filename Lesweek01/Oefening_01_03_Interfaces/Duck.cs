namespace Oefening_01_03_Interfaces;
public class Duck : Animal, IMakeSound, IAmAWaterAnimal
{
    public void MakeSound()
    {
        Console.WriteLine($"Kwak kwak, ik ben {Age} jaar");
    }
    public void Swim()
    {
        Console.WriteLine("De eend zwemt");
    }
}

