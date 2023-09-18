using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening03_Interfaces;
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

