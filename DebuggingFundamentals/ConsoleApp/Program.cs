using System;
using Task1;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new[] { 4, 2, 1, 3, -5 };
            //Utilities.Sort(numbers);
            //Utilities.Sort(null);

            var products = new Product[]
            {
                new Product("Product 1", 10.0d),
                new Product("Product 2", 20.0d),
                new Product("Product 3", 30.0d),
            };

            var productToFind = 42;

            int index = Utilities.IndexOf(products, product => product.Equals(productToFind));
        }
    }
}
