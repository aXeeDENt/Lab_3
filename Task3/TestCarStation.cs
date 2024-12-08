using System;
using System.Diagnostics;
using System.IO;
using Task2;

namespace Task3
{
    class TestCarStation
    {
        public static void Main(string[] args)
        {
            // Arrange
            var carStation = new CarStation(new PeopleDinner(), new GasStation());

            var helper = new ConsoleOutputHelper();

            // Add cars to the station
            carStation.AddCar(new Car("Car1", true, false));  // Needs dinner, no refuel
            carStation.AddCar(new Car("Car2", false, true)); // No dinner, needs refuel

            // Act: Serve cars
            carStation.ServeCars();

            // Get the captured output
            string output = helper.GetOutput();

            // Debugging: Output the captured output
            Console.WriteLine("Captured output after serving cars:");
            Console.WriteLine(output);

            // Assert: Use Debug.Assert to check if output contains expected strings
            Debug.Assert(output.Contains("Serving dinner to people in car Car1"), "PeopleDinner did not serve Car1 correctly.");
            Debug.Assert(!output.Contains("Refueling gas car Car1"), "Car1 should not be refueled.");
            Debug.Assert(output.Contains("Serving dinner to people in car Car2"), "PeopleDinner did not serve Car2 correctly.");
            Debug.Assert(output.Contains("Refueling gas car Car2"), "GasStation did not refuel Car2 correctly.");

            // Reset the console output
            helper.Reset();

            // Serve all cars again and capture output for further verification
            using (var consoleOutput = new ConsoleOutputHelper())
            {
                carStation.ServeCars();

                string output2 = consoleOutput.GetOutput();

                // Debugging: Output the captured output for second serving
                Console.WriteLine("Captured output after second serving:");
                Console.WriteLine(output2);

                // Assertions for Car1
                Debug.Assert(output2.Contains("Serving dinner to people in car Car1"),
                    "Car1 was not served dinner correctly.");
                Debug.Assert(!output2.Contains("Refueling gas car Car1"),
                    "Car1 was refueled incorrectly.");

                // Assertions for Car2
                Debug.Assert(output2.Contains("Refueling gas car Car2"),
                    "Car2 was not refueled correctly.");
                Debug.Assert(!output2.Contains("Serving dinner to people in car Car2"),
                    "Car2 was served dinner incorrectly.");

                // Assertions for Car3 (if exists)
                Debug.Assert(output2.Contains("Serving dinner to people in car Car3"),
                    "Car3 was not served dinner correctly.");
                Debug.Assert(output2.Contains("Refueling gas car Car3"),
                    "Car3 was not refueled correctly.");
            }

            Console.WriteLine("All tests passed!");
        }

        public class ConsoleOutputHelper : IDisposable
        {
            private StringWriter stringWriter;
            private TextWriter originalOutput;

            public ConsoleOutputHelper()
            {
                stringWriter = new StringWriter();
                originalOutput = Console.Out;
                Console.SetOut(stringWriter);
            }

            public string GetOutput()
            {
                return stringWriter.ToString();
            }

            public void Reset()
            {
                Console.SetOut(originalOutput);
                stringWriter.Dispose();
            }

            public void Dispose()
            {
                // Reset console output and release resources
                Console.SetOut(originalOutput);
                stringWriter.Dispose();
            }
        }
    }
}
