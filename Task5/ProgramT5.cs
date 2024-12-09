using System;
using System.IO;
using Task5; 

namespace Task5
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting the car management system...");

            CheckAndProcessExistingCarFiles();

            CarStationManager.MonitorQueueDirectory();
        }

        private static void CheckAndProcessExistingCarFiles()
        {
            var queueDirectory = @"C:\Users\user\Documents\MyCSharpProjects\OOP_Labs\Lab_3\queue";
            if (Directory.Exists(queueDirectory))
            {
                var carFiles = Directory.GetFiles(queueDirectory, "*.json");

                foreach (var file in carFiles)
                {
                    Console.WriteLine($"Processing existing car file: {file}");
                    CarStationManager.ProcessCarFile(file); 
                }
            }
        }
    }
}
