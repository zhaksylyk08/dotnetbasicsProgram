using System;

namespace Katas
{
    public class StringSum
    {
        public string Sum(string num1, string num2)
        {
            int n1, n2;
            int sum = 0;

            try
            {
                n1 = Int32.Parse(num1);
                n2 = Int32.Parse(num2);

                n1 = n1 < 0 ? 0 : n1;
                n2 = n2 < 0 ? 0 : n2;

                sum = n1 + n2;
            }
            catch (FormatException)
            {

            }
            catch (OverflowException)
            {
                n1 = 0;
                n2 = 0;
            }

            return sum.ToString();
        }
    }
}
