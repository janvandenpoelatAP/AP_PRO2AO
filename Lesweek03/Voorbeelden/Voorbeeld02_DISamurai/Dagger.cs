using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voorbeeld02_DISamurai;
public class Dagger : IWeapon
{
    public void Hit(string target)
    {
        Console.WriteLine($"Stab {target}  to death");
    }
}