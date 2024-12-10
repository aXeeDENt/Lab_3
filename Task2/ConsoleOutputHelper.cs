using System;
using System.IO;

namespace Task2
{
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

        public string GetLastMessage()
        {
            string output = stringWriter.ToString();
            string[] lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            return lines.Length > 0 ? lines[^1] : string.Empty;
        }

        public void Dispose()
        {
            Console.SetOut(originalOutput); // Restore original Console output
            stringWriter.Dispose();
        }
    }
}
