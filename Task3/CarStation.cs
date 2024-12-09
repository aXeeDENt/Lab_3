using Task2;
namespace Task3
{
    public abstract class CarStation
    {
        public string Name { get; set; }
    }

    public class PeopleGasStation : CarStation, IRefuelable, IDineable
    {
        public PeopleGasStation() { Name = "People Gas Station"; }

        public void ServeFood(string passengers)
        {
            Console.WriteLine("Serving food at People Gas Station.");
        }

        public void Refuel(string fuelType)
        {
            Console.WriteLine($"Refueling at People Gas Station with {fuelType}.");
        }
    }

    public class PeopleElectricStation : CarStation, IRefuelable, IDineable
    {
        public PeopleElectricStation() { Name = "People Electric Station"; }

        public void ServeFood(string passengers)
        {
            Console.WriteLine("Serving food at People Electric Station.");
        }

        public void Refuel(string fuelType)
        {
            Console.WriteLine($"Refueling at People Electric Station with {fuelType}.");
        }
    }

    public class RobotGasStation : CarStation, IRefuelable
    {
        public RobotGasStation() { Name = "Robot Gas Station"; }

        public void Refuel(string fuelType)
        {
            Console.WriteLine($"Refueling at Robot Gas Station with {fuelType}.");
        }
    }

    public class RobotElectricStation : CarStation, IRefuelable
    {
        public RobotElectricStation() { Name = "Robot Electric Station"; }

        public void Refuel(string fuelType)
        {
            Console.WriteLine($"Refueling at Robot Electric Station with {fuelType}.");
        }
    }
}
