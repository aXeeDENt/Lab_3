using System;
using System.Diagnostics;
using System.Threading;

namespace Task5
{
    public class Threading
    {
        public static void Main(string[] args)
        {
            // Thread to run generator.py
            Thread pythonThread = new Thread(RunPythonScript);
            
            // Thread to run Task5.csproj
            Thread task5Thread = new Thread(RunTask5);

            // Start the threads
            pythonThread.Start();

            // Wait for the generator.py to finish before starting Task5
            pythonThread.Join();
            task5Thread.Start();

            // Wait for Task5 to complete
            task5Thread.Join();

            Console.WriteLine("Both threads have completed their tasks.");
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
                Console.WriteLine("Starting Task5 directly...");
                Task5.ProgramT5.Main(new string[0]).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while running Task5: {ex.Message}");
            }
        }
    }
}
