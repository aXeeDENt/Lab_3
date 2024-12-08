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
            if (passengers == "PEOPLE")
            {
                Console.WriteLine("Serving food at People Gas Station.");
            }
            else
            {
                Console.WriteLine("This station only serves food to people.");
            }
        }

        public void Refuel(string fuelType)
        {
            if (fuelType == "GAS")
            {
                Console.WriteLine("Refueling at People Gas Station with Gas.");
            }
            else
            {
                Console.WriteLine("This station doesn't provide Electric fueling.");
            }
        }
    }

    public class PeopleElectricStation : CarStation, IRefuelable, IDineable
    {
        public PeopleElectricStation() { Name = "People Electric Station"; }

        public void ServeFood(string passengers)
        {
            if (passengers == "PEOPLE")
            {
                Console.WriteLine("Serving food at People Electric Station.");
            }
            else
            {
                Console.WriteLine("This station only serves food to people.");
            }
        }

        public void Refuel(string fuelType)
        {
            if (fuelType == "ELECTRIC")
            {
                Console.WriteLine("Refueling at People Electric Station with Electric.");
            }
            else
            {
                Console.WriteLine("This station doesn't provide Gas fueling.");
            }
        }
    }

    public class RobotGasStation : CarStation, IRefuelable
    {
        public RobotGasStation() { Name = "Robot Gas Station"; }

        public void Refuel(string fuelType)
        {
            if (fuelType == "GAS")
            {
                Console.WriteLine("Refueling at Robot Gas Station with Gas.");
            }
            else
            {
                Console.WriteLine("This station doesn't provide Electric fueling.");
            }
        }
    }

    public class RobotElectricStation : CarStation, IRefuelable
    {
        public RobotElectricStation() { Name = "Robot Electric Station"; }

        public void Refuel(string fuelType)
        {
            if (fuelType == "ELECTRIC")
            {
                Console.WriteLine("Refueling at Robot Electric Station with Electric.");
            }
            else
            {
                Console.WriteLine("This station doesn't provide Gas fueling.");
            }
        }
    }
}
