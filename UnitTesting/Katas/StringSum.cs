using System;

namespace Katas
{
    public class StringSum
    {
        public string Sum(string num1, string num2)
        {
            Int32.TryParse(num1, out int num1Value);
            Int32.TryParse(num2, out int num2Value);

            num1Value = num1Value < 0 ? 0 : num1Value;
            num2Value = num2Value < 0 ? 0 : num2Value;

            int sum = num1Value + num2Value;

            return sum.ToString();
        }
    }
}
