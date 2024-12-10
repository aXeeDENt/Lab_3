using System;
using Task3;

namespace Task4
{
    public class SemaphoreTest
    {
        public static void Main(string[] args)
        {
            Semaphore semaphore = new Semaphore();

            Car car1 = new Car(1, "GAS", "PEOPLE", false, 10);
            Car car2 = new Car(2,  "ELECTRIC", "PEOPLE",false, 8);
            Car car3 = new Car(3,  "GAS", "ROBOT",false, 12);
            Car car4 = new Car(4,  "ELECTRIC", "ROBOT",false, 7);

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
