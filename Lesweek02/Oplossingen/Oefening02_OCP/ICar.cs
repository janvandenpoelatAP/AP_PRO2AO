using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening02_OCP;
public interface ICar
{
    string Name { get; }
    string GetMileage();
}