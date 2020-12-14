using System;
using ClassLibrary;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var name = args[0];
                Console.WriteLine(Class1.SayHello(name));
            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("args is null");
            }
        }
    }
}
