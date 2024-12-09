using System;
using System.Collections.Generic;

namespace Task3
{
    public abstract class CarStation
    {
        public string Name { get; set; }
        protected Queue<Car> CarsQueue { get; } = new Queue<Car>();

        public void AddCar(Car car)
        {
            CarsQueue.Enqueue(car);
            Console.WriteLine($"Car {car.CarId} added to {Name} queue.");
        }

        public abstract void ServeCars();
    }

    public class PeopleGasStation : CarStation
    {
        public PeopleGasStation() { Name = "People Gas Station"; }

        public override void ServeCars()
        {
            while (CarsQueue.Count > 0)
            {
                var car = CarsQueue.Dequeue();
                Console.WriteLine($"Serving {car.CarId} at {Name} (Gas Refuel)");
            }
        }
    }

    public class PeopleElectricStation : CarStation
    {
        public PeopleElectricStation() { Name = "People Electric Station"; }

        public override void ServeCars()
        {
            while (CarsQueue.Count > 0)
            {
                var car = CarsQueue.Dequeue();
                Console.WriteLine($"Serving {car.CarId} at {Name} (Electric Refuel)");
            }
        }
    }

    public class RobotGasStation : CarStation
    {
        public RobotGasStation() { Name = "Robot Gas Station"; }

        public override void ServeCars()
        {
            while (CarsQueue.Count > 0)
            {
                var car = CarsQueue.Dequeue();
                Console.WriteLine($"Serving {car.CarId} at {Name} (Gas Refuel)");
            }
        }
    }

    public class RobotElectricStation : CarStation
    {
        public RobotElectricStation() { Name = "Robot Electric Station"; }

        public override void ServeCars()
        {
            while (CarsQueue.Count > 0)
            {
                var car = CarsQueue.Dequeue();
                Console.WriteLine($"Serving {car.CarId} at {Name} (Electric Refuel)");
            }
        }
    }
}
