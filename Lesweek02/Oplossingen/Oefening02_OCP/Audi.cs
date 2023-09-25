using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening02_OCP;
public class Audi : ICar
{
    public string Name => "Audi";

    public string GetMileage()
    {
        return "10M";
    }
}
