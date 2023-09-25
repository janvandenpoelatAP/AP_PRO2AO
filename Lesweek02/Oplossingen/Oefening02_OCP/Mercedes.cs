using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening02_OCP;
public class Mercedes : ICar
{
    public string Name => "Mercedes";

    public string GetMileage()
    {
        return "20M";
    }
}
