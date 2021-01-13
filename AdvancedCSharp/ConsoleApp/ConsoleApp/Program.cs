using System;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string root = @"C:\dotnetmentoring";

            FileSystemVisitor.Started += () => { Console.WriteLine("FileSystemVisitor started searching..."); };
            FileSystemVisitor.Finished += () => { Console.WriteLine("FileSystemVisitor finished searching..."); };
            FileSystemVisitor.DirectoryFound += (object sender, ItemFoundEventArgs<DirectoryInfo> e) =>
            {
                Console.WriteLine($"{e.FoundItemInfo.Name} is found");
                e.CancelRequested = true;
            };

            var fileSystemVisitor = new FileSystemVisitor(root);

            foreach (var item in fileSystemVisitor)
            {
                Console.WriteLine(item);
            }
        }
    }
}
