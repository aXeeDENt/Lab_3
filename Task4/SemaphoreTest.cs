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
            

            var car1 = new Car("Car1", true, "GAS", "PEOPLE", 10);
            var result1 = semaphore.RouteCar(car1);
            Console.WriteLine($"Route result: {result1}");
            Debug.Assert(result1 == "People Gas Station", "Expected result mismatch.");

            var car2 = new Car("Car2", false, "ELECTRIC", "PEOPLE", 11);
            var result2 = semaphore.RouteCar(car2);
            Console.WriteLine($"Route result: {result2}");
            Debug.Assert((result2 == "People Electric Station") || (result2 == "Robot Electric Station"), "Expected result mismatch.");

            var car3 = new Car("Car3", true, "ELECTRIC", "ROBOT", 5);
            var result3 = semaphore.RouteCar(car3);
            Console.WriteLine($"Route result: {result3}");
            Debug.Assert(result3 == "Robot Electric Station", "Expected result mismatch.");

            var car4 = new Car("Car4", false, "GAS", "ROBOT", 52);
            var result4 = semaphore.RouteCar(car4);
            Console.WriteLine($"Route result: {result4}");
            Debug.Assert((result4 == "People Gas Station") || (result4 == "Robot Gas Station"), "Expected result mismatch.");

            Console.WriteLine("All tests passed!");
        }
    }
}
