using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("To terminate the program, enter exit.");

            while (true)
            {
                Console.WriteLine("Enter the line:");

                var input = Console.ReadLine();

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                try
                {
                    var result = input[0];
                    Console.WriteLine(result);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("You entered empty line.");
                }
            }
        }
    }
}
