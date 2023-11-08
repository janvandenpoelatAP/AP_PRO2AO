namespace Oefening_01_03_Interfaces;
public class Fish : Animal, IAmAWaterAnimal
{
    public void Swim()
    {
        Console.WriteLine("De vis zwemt");
    }
}
