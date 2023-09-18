using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening02_Casting;
public class Square
{
    private int size;
    public Square(int size)
    {
        this.size = size;
    }
    public int Perimeter
    {
        get
        {
            return size * 4;
        }
    }
}
