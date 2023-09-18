using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening04_CastingInheritance;
public class Restaurant : Building
{
    public int NumberOfTables { get; set; }
    public CuisineType CuisineType { get; set; }
}
