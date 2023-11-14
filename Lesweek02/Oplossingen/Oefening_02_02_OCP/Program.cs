using Oefening_02_02_OCP;

List<string> carNames = new List<string>()
{
    "Audi",
    "Mercedes"
};
var mileageCalculator = new MileageCalculator(carNames);
mileageCalculator.CalculateMileage();
