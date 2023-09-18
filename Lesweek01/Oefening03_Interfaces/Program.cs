using Oefening03_Interfaces;

var animals = new List<Animal>();
animals.Add(new Fish { Age = 5 });
animals.Add(new Duck() { Age = 9 });
animals.Add(new Duck() { Age = 3 });
animals.Add(new Dog() { Age = 5 });

foreach (var animal in animals)
{
    var sound = animal as IMakeSound;
    if (sound != null)
    {
        sound.MakeSound();
    }
    var waterAnimal = animal as IAmAWaterAnimal;
    if (waterAnimal != null)
    {
        waterAnimal.Swim();
    }
    Console.WriteLine();
}
Console.ReadLine();