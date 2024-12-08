using System;
using System.Collections.Generic;
using Task2;

namespace Task3
{
    public class CarStation
    {
        private Dineable diningService;
        private Refuelable refuelingService;
        private Queue<Car> queue;

        public CarStation(Dineable diningService, Refuelable refuelingService)
        {
            this.diningService = diningService;
            this.refuelingService = refuelingService;
            this.queue = new Queue<Car>();
        }

        public void AddCar(Car car)
        {
            queue.Enqueue(car);
            Console.WriteLine($"Car {car.CarId} added to the queue.");
        }

        public void ServeCars()
        {
            while (queue.Count > 0)
            {
                Car currentCar = queue.Dequeue();

                if (currentCar.NeedsDinner)
                {
                    diningService.ServeDinner(currentCar.CarId);
                }

                if (currentCar.NeedsRefuel)
                {
                    refuelingService.Refuel(currentCar.CarId);
                }

                Console.WriteLine($"Car {currentCar.CarId} served and removed from the queue.");
            }
        }
    }
}