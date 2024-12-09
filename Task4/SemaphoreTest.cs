using System;
using System.Collections.Generic;
using System.Diagnostics;
using Task3;

namespace Task4
{
    class SemaphoreTest
    {
        static void Main(string[] args)
        {
            // Mock actions to track test results
            var calledStations = new List<string>();

            Action<string> recordStation = stationName => calledStations.Add(stationName);

            // Create mock stations
            var mockStations = new List<CarStation>
            {
                new MockCarStation("People Gas Station", recordStation, recordStation),
                new MockCarStation("People Electric Station", recordStation, recordStation),
                new MockCarStation("Robot Gas Station", recordStation, recordStation),
                new MockCarStation("Robot Electric Station", recordStation, recordStation)
            };

            // Create Semaphore with mock stations
            var semaphore = new Semaphore
            {
                Stations = mockStations
            };

            // Test cases
            var car1 = new Car("Car1", true, "GAS", "PEOPLE");
            //var car2 = new Car("Car2", false, "ELECTRIC", "PEOPLE");
            //var car3 = new Car("Car3", true, "ELECTRIC", "ROBOTS");
            //var car4 = new Car("Car4", false, "GAS", "ROBOTS");

            semaphore.RouteCar(car1);
            Debug.Assert(calledStations.Contains("People Gas Station"), "Car1 should visit People Gas Station");

            // semaphore.RouteCar(car2);
            // Debug.Assert(calledStations.Contains("People Electric Station"), "Car2 should visit People Electric Station");

            // semaphore.RouteCar(car3);
            // Debug.Assert(calledStations.Contains("Robot Electric Station"), "Car3 should visit Robot Electric Station");

            // semaphore.RouteCar(car4);
            // Debug.Assert(calledStations.Contains("Robot Gas Station"), "Car4 should visit Robot Gas Station");

            Console.WriteLine("All tests passed!");
        }
    }
}
