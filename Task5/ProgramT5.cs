using System;
using System.IO;
using System.Text.Json;
using Task3;
using Task4;

namespace Task5
{
    public class ProgramT5
    {
        public static void Main(string[] args)
        {
            string queueDir = Path.Combine("queue");
            string stationDir = Path.Combine("CarStations");

            // Ensure station directories exist
            Directory.CreateDirectory(Path.Combine(stationDir, "PeopleGasStation"));
            Directory.CreateDirectory(Path.Combine(stationDir, "PeopleElectricStation"));
            Directory.CreateDirectory(Path.Combine(stationDir, "RobotGasStation"));
            Directory.CreateDirectory(Path.Combine(stationDir, "RobotElectricStation"));

            Task4.Semaphore semaphore = new Task4.Semaphore();

            // Process each .json file in the queue directory
            foreach (var filePath in Directory.GetFiles(queueDir, "*.json"))
            {
                try
                {
                    // Read and deserialize the car JSON
                    string carJson = File.ReadAllText(filePath);
                    Car car = JsonSerializer.Deserialize<Car>(carJson);

                    if (car == null)
                    {
                        Console.WriteLine($"Error: File {filePath} could not be deserialized.");
                        continue;
                    }

                    // Route the car using Semaphore
                    semaphore.RouteCar(car);

                    // Determine the destination folder based on the car's assigned station
                    bool carRouted = false;
                    foreach (var station in semaphore.Stations)
                    {
                        if (station.CarsQueue.Contains(car))
                        {
                            string stationFolder = Path.Combine(stationDir, station.Name);
                            string destinationPath = Path.Combine(stationFolder, Path.GetFileName(filePath));

                            File.Move(filePath, destinationPath);
                            Console.WriteLine($"Car {car.id} moved to {station.Name}.");
                            carRouted = true;
                            break;
                        }
                    }

                    if (!carRouted)
                    {
                        Console.WriteLine($"Warning: Car {car.id} could not be routed to any station.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing file {filePath}: {ex.Message}");
                }
            }

            Console.WriteLine("All cars have been routed.");
        }
    }
}
