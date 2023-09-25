using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening02_OCP;
public class CarController
{
    List<ICar> cars;
    public CarController()
    {
        cars = new List<ICar>
        {
            new Audi(),
            new Mercedes()
        };
    }

    public string GetCarMileage(string name)
    {
        return cars.First(car => car.Name == name).GetMileage();
    }
}
