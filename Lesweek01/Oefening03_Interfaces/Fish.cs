using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening03_Interfaces;
public class Fish : Animal, IAmAWaterAnimal
{
    public void Swim()
    {
        Console.WriteLine("De vis zwemt");
    }
}
