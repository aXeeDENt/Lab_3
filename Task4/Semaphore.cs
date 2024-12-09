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
            // Handle cars that need dining and refueling
            foreach (var station in Stations)
            {
                if (station.Name == "People Gas Station" && car.NeedsDinner && car.Passengers == "PEOPLE" && car.FuelType == "GAS")
                {
                    ((IDineable)station).ServeFood(car.Passengers);
                    ((IRefuelable)station).Refuel(car.FuelType);
                    return "People Gas Station";
                }
                else if (station.Name == "People Electric Station" && car.NeedsDinner && car.Passengers == "PEOPLE" && car.FuelType == "ELECTRIC")
                {
                    ((IDineable)station).ServeFood(car.Passengers);
                    ((IRefuelable)station).Refuel(car.FuelType);
                    return "People Electric Station";
                }
                else if (station.Name == "Robot Gas Station" && car.NeedsDinner && car.Passengers == "ROBOT" && car.FuelType == "GAS")
                {
                    ((IDineable)station).ServeFood(car.Passengers);
                    ((IRefuelable)station).Refuel(car.FuelType);
                    return "Robot Gas Station";
                }
                else if (station.Name == "Robot Electric Station" && car.NeedsDinner && car.Passengers == "ROBOT" && car.FuelType == "ELECTRIC")
                {
                    ((IDineable)station).ServeFood(car.Passengers);
                    ((IRefuelable)station).Refuel(car.FuelType);
                    return "Robot Electric Station";
                }
            }

            // Handle cars that only need refueling
            foreach (var station in Stations)
            {
                if (station.Name == "People Gas Station" && !car.NeedsDinner && 
                ((car.Passengers == "PEOPLE") || (car.Passengers == "ROBOT")) && car.FuelType == "GAS")
                {
                    ((IRefuelable)station).Refuel(car.FuelType);
                    return "People Gas Station";
                }
                else if (station.Name == "People Electric Station" && !car.NeedsDinner && 
                ((car.Passengers == "PEOPLE") || (car.Passengers == "ROBOT")) && car.FuelType == "ELECTRIC")
                {
                    ((IRefuelable)station).Refuel(car.FuelType);
                    return "People Electric Station";
                }
                else if (station.Name == "Robot Gas Station" && !car.NeedsDinner && 
                ((car.Passengers == "ROBOT") || (car.Passengers == "PEOPLE")) && car.FuelType == "GAS")
                {
                    ((IRefuelable)station).Refuel(car.FuelType);
                    return "Robot Gas Station";
                }
                else if (station.Name == "Robot Electric Station" && !car.NeedsDinner && 
                ((car.Passengers == "ROBOT") || (car.Passengers == "PEOPLE")) && car.FuelType == "ELECTRIC")
                {
                    ((IRefuelable)station).Refuel(car.FuelType);
                    return "Robot Electric Station";
                }
            }

            return $"{car.CarId} could not find a suitable station.";
        }
    }
}
