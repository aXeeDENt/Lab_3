using System;
using Task3;

namespace Task4
{
    public class SemaphoreTest
    {
        public static void Main(string[] args)
        {
            Semaphore semaphore = new Semaphore();

            Car car1 = new Car("Car1", false, "GAS", "PEOPLE", 10);
            Car car2 = new Car("Car2", false, "ELECTRIC", "PEOPLE", 8);
            Car car3 = new Car("Car3", false, "GAS", "ROBOT", 12);
            Car car4 = new Car("Car4", false, "ELECTRIC", "ROBOT", 7);

            semaphore.RouteCar(car1);
            semaphore.RouteCar(car2);
            semaphore.RouteCar(car3);
            semaphore.RouteCar(car4);

            foreach (var station in semaphore.Stations)
            {
                station.ServeCars();
            }

            Console.WriteLine("All cars have been served.");
        }
    }
}
