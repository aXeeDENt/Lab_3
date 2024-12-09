using System;
using System.Threading.Tasks;
using Task4;
using Task3;

namespace Task5
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Start the task scheduler to read and serve cars concurrently
            await TaskScheduler.StartTasks();
        }
    }
}
