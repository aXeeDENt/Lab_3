using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks; // For Task.Delay
using Task3;
using Task4;

namespace Task5
{
    public class ProgramT5
    {
        public static async Task Main(string[] args)
        {
            string queueDir = Path.Combine("queue");
            string stationDir = Path.Combine("CarStations");

            // Station names
            string[] stationNames = new[]
            {
                "People Gas Station",
                "People Electric Station",
                "Robot Gas Station",
                "Robot Electric Station"
            };

            // Ensure station directories exist and clean them
            foreach (var stationName in stationNames)
            {
                string stationPath = Path.Combine(stationDir, stationName);
                Directory.CreateDirectory(stationPath); // Create the folder if it doesn't exist

                // Clean the station folder
                foreach (var file in Directory.GetFiles(stationPath))
                {
                    File.Delete(file);
                }
            }

            Task4.Semaphore semaphore = new Task4.Semaphore();

            // Continuously process files until no files remain in the queue directory
            while (true)
            {
                var files = Directory.GetFiles(queueDir, "*.json");
                if (files.Length == 0)
                {
                    Console.WriteLine("No more files to process. Exiting...");
                    break; // Exit when no more files are found
                }

                foreach (var filePath in files)
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
                                // Calculate delay based on car's consumption
                                int delayTime = (car.consumption / 10) * 1000; // Convert seconds to milliseconds
                                await Task.Delay(delayTime);

                                string stationFolder = Path.Combine(stationDir, station.Name);
                                string destinationPath = Path.Combine(stationFolder, Path.GetFileName(filePath));

                                File.Move(filePath, destinationPath);
                                Console.WriteLine($"Car {car.id} with consumption {car.consumption} moved to {station.Name} after {delayTime / 1000} seconds.");
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
            }

            Console.WriteLine("All cars have been routed.");
        }
    }
}
