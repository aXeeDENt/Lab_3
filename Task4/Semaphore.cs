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
                if (station.Name.Contains("People") && car.Passengers == "PEOPLE" && car.FuelType == "GAS" && station is PeopleGasStation)
                {
                    station.AddCar(car);
                    return;
                }
                else if (station.Name.Contains("Robot") && car.Passengers == "ROBOT" && car.FuelType == "GAS" && station is RobotGasStation)
                {
                    station.AddCar(car);
                    return;
                }
                else if (station.Name.Contains("People") && car.Passengers == "PEOPLE" && car.FuelType == "ELECTRIC" && station is PeopleElectricStation)
                {
                    station.AddCar(car);
                    return;
                }
                else if (station.Name.Contains("Robot") && car.Passengers == "ROBOT" && car.FuelType == "ELECTRIC" && station is RobotElectricStation)
                {
                    station.AddCar(car);
                    return;
                }
            }

            Console.WriteLine($"Car {car.CarId} could not be routed to any station.");
        }
    }
}
