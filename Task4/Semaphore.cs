using Task3;
using Task2;
using System;
using System.Collections.Generic;

namespace Task4
{
    public class Semaphore
    {
        private List<CarStation> stations;

        public Semaphore()
        {
            // Initialize the four types of stations
            stations = new List<CarStation>
            {
                new PeopleGasStation(),
                new PeopleElectricStation(),
                new RobotGasStation(),
                new RobotElectricStation()
            };
        }

        public void RouteCar(Car car)
        {
            foreach (var station in stations)
            {
                if (car.NeedsDinner)
                {
                    // Check if the car needs food, and serve it if this station serves food
                    if (station is IDineable)
                    {
                        Console.WriteLine($"{car.CarId} is visiting {station.Name}");
                        (station as IDineable)?.ServeFood(car.Passengers);
                    }
                }

                if (car.NeedsRefuel)
                {
                    // Check if the car needs fuel, and refuel it if this station can refuel it
                    if (station is IRefuelable)
                    {
                        Console.WriteLine($"{car.CarId} is visiting {station.Name}");
                        (station as IRefuelable)?.Refuel(car.FuelType);
                    }
                }
            }
        }
    }
}
