using Oefening_02_02_OCP_OPG;

List<Car> cars = new List<Car>()
{
    new Car() { Name = "Audi" },
    new Car() { Name = "Mercedes"}
};

var mileageCalculator = new MileageCalculator(cars);
mileageCalculator.CalculateMileage();