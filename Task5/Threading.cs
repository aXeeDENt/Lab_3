using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Task4;
using Task3;

namespace Task5
{
    public class TaskScheduler
    {
        private static readonly string folderPath = @"C:\Documents\MyCSharp\OOP_Labs\Lab_3\queue";  // Path to the folder where JSON files are stored
        private static readonly int readInterval = 5 * 1000; // Interval for reading files in milliseconds (5 seconds)
        private static readonly int serveInterval = 5 * 1000; // Interval for serving cars in milliseconds (5 seconds)

        private static CarStation carStation = new CarStation();

        public static async Task ReadCarsTask()
        {
            while (true)
            {
                // Read all JSON files in the folder
                string[] files = Directory.GetFiles(folderPath, "*.json");

                foreach (var file in files)
                {
                    // Simulate reading car data from JSON file (you can implement actual JSON deserialization here)
                    string carData = File.ReadAllText(file);
                    Car car = new Car("Model", "Make");  // This is a placeholder. Replace with actual deserialization.

                    // Add the car to the CarStation
                    carStation.AddCar(car);
                    Console.WriteLine($"Added car from {file}");
                }

                // Wait for the next reading interval
                await Task.Delay(readInterval);
            }
        }

        public static async Task ServeCarsTask()
        {
            while (true)
            {
                // Serve the cars
                carStation.ServeCars();
                
                // Wait for the next serving interval
                await Task.Delay(serveInterval);
            }
        }

        public static async Task StartTasks()
        {
            // Start the tasks for reading cars and serving cars
            var readTask = Task.Run(() => ReadCarsTask());
            var serveTask = Task.Run(() => ServeCarsTask());

            // Wait for both tasks to complete
            await Task.WhenAny(readTask, serveTask);
        }
    }
}
