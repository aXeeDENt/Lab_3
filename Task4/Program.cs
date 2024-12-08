using Task3;
using Task2;
using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a few cars with different needs and passenger types
            var car1 = new Car("Car1", needsDinner: true, needsRefuel: true, fuelType: "Gas", passengers: "PEOPLE");
            var car2 = new Car("Car2", needsDinner: false, needsRefuel: true, fuelType: "Electric", passengers: "PEOPLE");
            var car3 = new Car("Car3", needsDinner: true, needsRefuel: false, fuelType: "Electric", passengers: "PEOPLE");
            var car4 = new Car("Car4", needsDinner: true, needsRefuel: true, fuelType: "Gas", passengers: "ROBOTS");

            // Create Semaphore to manage car routing
            var semaphore = new Semaphore();

            // Route each car to appropriate stations
            semaphore.RouteCar(car1);
            semaphore.RouteCar(car2);
            semaphore.RouteCar(car3);
            semaphore.RouteCar(car4);
        }
    }
}
