namespace Oefening_02_02_OCP;
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