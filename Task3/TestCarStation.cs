using System;
using Task2;
using Task3;

namespace Task3
{
    class TestCarStation
    {
        public static void Main(string[] args)
        {
            // Creating station instances
            var peopleGasStation = new CarStation(new GasStation(), new PeopleDinner());
            var peopleElectricStation = new CarStation(new ElectricStation(), new PeopleDinner());
            var robotGasStation = new CarStation(new GasStation(), new RobotDinner());
            var robotElectricStation = new CarStation(new ElectricStation(), new RobotDinner());

            // Creating cars with different types and passengers
            var car1 = new Car("Car1", true, true, "GAS", "ROBOTS");  // Needs both dining and gas refuel
            var car2 = new Car("Car2", false, true, "ELECTRIC", "PEOPLE");  // Needs only electric refuel
            var car3 = new Car("Car3", true, false, "ELECTRIC", "PEOPLE"); // Needs dining only
            var car4 = new Car("Car4", false, false, "GAS", "PEOPLE");    // Needs neither

            // Testing with different stations
            TestStation(peopleGasStation, car1);
            TestStation(peopleElectricStation, car2);
            TestStation(robotGasStation, car3);
            TestStation(robotElectricStation, car4);
        }

        private static void TestStation(CarStation station, Car car)
        {
            Console.WriteLine($"\nTesting {station.GetType().Name}:");
            station.AddCar(car);
        }
    }
}
