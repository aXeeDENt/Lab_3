using System;
using System.IO;
using System.Text.Json;
using Task3; 

namespace Task5
{
    public class CarStationManager
    {
        private static readonly string QueueDirectory = @"C:\Users\user\Documents\MyCSharpProjects\OOP_Labs\Lab_3\queue";
        private static readonly string PeopleGasDirectory = @"C:\Users\user\Documents\MyCSharpProjects\OOP_Labs\Lab_3\carstations\peopleGas";
        private static readonly string PeopleElectricDirectory = @"C:\Users\user\Documents\MyCSharpProjects\OOP_Labs\Lab_3\carstations\peopleElectric";
        private static readonly string RobotGasDirectory = @"C:\Users\user\Documents\MyCSharpProjects\OOP_Labs\Lab_3\carstations\robotGas";
        private static readonly string RobotElectricDirectory = @"C:\Users\user\Documents\MyCSharpProjects\OOP_Labs\Lab_3\carstations\robotElectric";

        public static void MonitorQueueDirectory()
        {
            var watcher = new FileSystemWatcher(QueueDirectory)
            {
                Filter = "*.json",
                EnableRaisingEvents = true,
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite
            };

            watcher.Created += OnNewCarFileDetected;
            watcher.EnableRaisingEvents = true;

            Console.WriteLine($"Monitoring directory: {QueueDirectory}");
            Console.ReadLine();
        }

        public static void OnNewCarFileDetected(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"New car file detected: {e.FullPath}");
            ProcessCarFile(e.FullPath);
        }

        public static void ProcessCarFile(string filePath)
        {
            try
            {
                var carJson = File.ReadAllText(filePath);

                var car = JsonSerializer.Deserialize<Car>(carJson);

                Console.WriteLine($"Processing car: ID={car.CarId}, Type={car.FuelType}, Passengers={car.Passengers}, Consumption={car.Consumption}");

                string destinationDirectory = GetDestinationDirectory(car);

                if (destinationDirectory != null)
                {
                    var destinationPath = Path.Combine(destinationDirectory, Path.GetFileName(filePath));
                    File.Move(filePath, destinationPath);
                    Console.WriteLine($"Moved car file to the car station: {destinationPath}");
                }
                else
                {
                    Console.WriteLine("No matching car station found for this car.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing car file: {ex.Message}");
            }
        }

        private static string GetDestinationDirectory(Car car)
        {
            if (car.Passengers == "PEOPLE" && car.FuelType == "GAS")
                return PeopleGasDirectory;
            if (car.Passengers == "PEOPLE" && car.FuelType == "ELECTRIC")
                return PeopleElectricDirectory;
            if (car.Passengers == "ROBOTS" && car.FuelType == "GAS")
                return RobotGasDirectory;
            if (car.Passengers == "ROBOTS" && car.FuelType == "ELECTRIC")
                return RobotElectricDirectory;

            return null; 
        }
    }
}
