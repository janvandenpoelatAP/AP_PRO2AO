using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Oefening02_OCP;
public class MileageCalculator
{
    List<string> carNames;
    public MileageCalculator(List<string> carNames) 
    { 
        this.carNames = carNames; 
    }
    public void CalculateMileage()
    {
        CarController controller = new CarController();
        foreach (var carName in carNames)
        {
            Console.WriteLine("Mileage of the car {0} is {1}", carName, controller.GetCarMileage(carName));
        }
    }
}