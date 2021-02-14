using System;
using System.Collections.Generic;
using System.Text;

namespace Katas
{
    public class FizzBuzz
    {
        public List<string> Print()
        {
            var numbers = new List<string>();

            for (int i = 0; i < 100; i++)
            {
                int numValue = i + 1;
                string number = numValue.ToString();

                if (numValue % 3 == 0 && numValue % 5 == 0)
                {
                    number = "FizzBuzz";
                }
                else if (numValue % 3 == 0)
                {
                    number = "Fizz";
                }
                else if (numValue % 5 == 0)
                {
                    number = "Buzz";
                }

                numbers.Add(number);
            }

            return numbers;
        }
    }
}
