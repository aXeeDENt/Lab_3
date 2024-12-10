using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Task5
{
    public class Threading
    {
        public static async Task Main(string[] args)
        {
            // Create tasks for generator.py and Task5
            Task generatorTask = Task.Run(() => RunPythonScript());
            Task programT5Task = Task.Run(() => RunTask5());

            // Run both tasks concurrently
            await Task.WhenAll(generatorTask, programT5Task);

            Console.WriteLine("Both generator.py and ProgramT5 have completed.");
        }

        private static void RunPythonScript()
        {
            try
            {
                Console.WriteLine("Starting generator.py...");
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "python",
                    Arguments = "generator.py",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(startInfo))
                {
                    if (process != null)
                    {
                        string output = process.StandardOutput.ReadToEnd();
                        string error = process.StandardError.ReadToEnd();

                        process.WaitForExit();

                        Console.WriteLine(output);

                        if (!string.IsNullOrEmpty(error))
                        {
                            Console.WriteLine("Error:");
                            Console.WriteLine(error);
                        }
                    }
                }

                Console.WriteLine("generator.py has finished executing.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while running generator.py: {ex.Message}");
            }
        }

        private static void RunTask5()
        {
            try
            {
                Console.WriteLine("Starting ProgramT5...");
                Task5.ProgramT5.Main(new string[0]).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while running ProgramT5: {ex.Message}");
            }
        }
    }
}
