using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string root = @"C:\dotnetmentoring";

            FileSystemVisitor.Started += StartedWriteToConsole;
            FileSystemVisitor.Finished += FinishedWriteToConsole;

            var fileSystemVisitor = new FileSystemVisitor(root);

            foreach (var item in fileSystemVisitor)
            {
                Console.WriteLine(item);
            }
        }

        static void StartedWriteToConsole()
        {
            Console.WriteLine("FileSystemVisitor started searching...");
        }

        static void FinishedWriteToConsole()
        {
            Console.WriteLine("FileSystemVisitor finished searching...");
        }
    }
}
