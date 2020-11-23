using System;
using ClassLibrary;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine();
            Console.WriteLine(Class1.SayHello(name));
        }
    }
}
