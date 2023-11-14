namespace Oefening_02_02_OCP_OPG;
public class MileageCalculator
{
    private IEnumerable<Car> cars;
    public MileageCalculator(IEnumerable<Car> cars) 
    { 
        this.cars = cars; 
    }
    public void CalculateMileage()
    {
        foreach (var car in cars)
        {
            if (car.Name == "Audi")
                Console.WriteLine("Mileage of the car {0} is {1}", car.Name, "10M");
            else if (car.Name == "Mercedes")
                Console.WriteLine("Mileage of the car {0} is {1}", car.Name, "20M");
        }
    }
}