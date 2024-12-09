using Task3;
using Task2;
using System.Diagnostics;
using System.Collections.Generic;

namespace Task4
{
    public class Semaphore
    {
        // Allow external access to stations for testing
        public List<CarStation> Stations { get; set; }

        public Semaphore()
        {
            // Default initialization
            Stations = new List<CarStation>
            {
                new PeopleGasStation(),
                new PeopleElectricStation(),
                new RobotGasStation(),
                new RobotElectricStation()
            };
        }

        public string RouteCar(Car car)
        {
            Console.WriteLine($"Routing {car.CarId}...");
            
            // First, check for dining needs
            if (car.NeedsDinner)
            {
                Console.WriteLine($"Car {car.CarId} needs dinner.");
                foreach (var station in Stations)
                {
                    Console.WriteLine($"Checking station: {station.Name}");
                    if (station is IDineable dineableStation)
                    {
                        if (car.Passengers == "PEOPLE" && car.FuelType == "GAS" && station is PeopleGasStation)
                        {
                            Console.WriteLine($"{car.CarId} is dining at People Gas Station.");
                            dineableStation.ServeFood(car.Passengers);
                            return "People Gas Station";
                        }
                        else if (car.Passengers == "PEOPLE" && car.FuelType == "ELECTRIC" && station is PeopleElectricStation)
                        {
                            Console.WriteLine($"{car.CarId} is dining at People Electric Station.");
                            dineableStation.ServeFood(car.Passengers);
                            return "People Electric Station";
                        }
                        else if (car.Passengers == "ROBOTS" && car.FuelType == "GAS" && station is RobotGasStation)
                        {
                            Console.WriteLine($"{car.CarId} is dining at Robot Gas Station.");
                            dineableStation.ServeFood(car.Passengers);
                            return "Robot Gas Station";
                        }
                        else if (car.Passengers == "ROBOTS" && car.FuelType == "ELECTRIC" && station is RobotElectricStation)
                        {
                            Console.WriteLine($"{car.CarId} is dining at Robot Electric Station.");
                            dineableStation.ServeFood(car.Passengers);
                            return "Robot Electric Station";
                        }
                    }
                }
            }

            // Then, refuel the car
            foreach (var station in Stations)
            {
                Console.WriteLine($"Checking refuel at {station.Name}");
                if (car.FuelType == "GAS" && (station is PeopleGasStation || station is RobotGasStation))
                {
                    if (station is IRefuelable refuelableStation)
                    {
                        Console.WriteLine($"{car.CarId} is refueling at {station.Name}.");
                        refuelableStation.Refuel(car.FuelType);
                        return $"{station.Name}";
                    }
                }
                else if (car.FuelType == "ELECTRIC" && (station is PeopleElectricStation || station is RobotElectricStation))
                {
                    if (station is IRefuelable refuelableStation)
                    {
                        Console.WriteLine($"{car.CarId} is refueling at {station.Name}.");
                        refuelableStation.Refuel(car.FuelType);
                        return $"{station.Name}";
                    }
                }
            }

            return ($"{car.CarId} could not find a suitable station.");
        }

    }
}
