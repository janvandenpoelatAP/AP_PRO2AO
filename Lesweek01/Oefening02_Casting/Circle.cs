using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening02_Casting;
public class Circle
{
    private int radius;
    public Circle(int radius)
    {
        this.radius = radius;
    }
    public double Area
    {
        get { return radius * radius * Math.PI; }
    }
}
