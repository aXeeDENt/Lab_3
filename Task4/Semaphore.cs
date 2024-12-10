using System.Collections.Generic;
using Task3;

namespace Task4
{
    public class Semaphore
    {
        public List<CarStation> Stations { get; set; }

        public Semaphore()
        {
            Stations = new List<CarStation>
            {
                new PeopleGasStation(),
                new PeopleElectricStation(),
                new RobotGasStation(),
                new RobotElectricStation()
            };
        }

        public void RouteCar(Car car)
{
    foreach (var station in Stations)
    {
        if (station.Name.Contains("People", StringComparison.OrdinalIgnoreCase) &&
            car.passengers.Equals("PEOPLE", StringComparison.OrdinalIgnoreCase) &&
            car.type.Equals("GAS", StringComparison.OrdinalIgnoreCase) &&
            station is PeopleGasStation)
        {
            station.AddCar(car);
            return;
        }
        else if (station.Name.Contains("Robot", StringComparison.OrdinalIgnoreCase) &&
                 car.passengers.Equals("ROBOTS", StringComparison.OrdinalIgnoreCase) &&
                 car.type.Equals("GAS", StringComparison.OrdinalIgnoreCase) &&
                 station is RobotGasStation)
        {
            station.AddCar(car);
            return;
        }
        else if (station.Name.Contains("People", StringComparison.OrdinalIgnoreCase) &&
                 car.passengers.Equals("PEOPLE", StringComparison.OrdinalIgnoreCase) &&
                 car.type.Equals("ELECTRIC", StringComparison.OrdinalIgnoreCase) &&
                 station is PeopleElectricStation)
        {
            station.AddCar(car);
            return;
        }
        else if (station.Name.Contains("Robot", StringComparison.OrdinalIgnoreCase) &&
                 car.passengers.Equals("ROBOTS", StringComparison.OrdinalIgnoreCase) &&
                 car.type.Equals("ELECTRIC", StringComparison.OrdinalIgnoreCase) &&
                 station is RobotElectricStation)
        {
            station.AddCar(car);
            return;
        }
    }

    Console.WriteLine($"Car {car.id} could not be routed to any station.");
}

    }
}
