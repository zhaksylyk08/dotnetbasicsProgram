using System;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            int result = 0;
            int degree = 0;
            int sum = 0;

            checked
            {
                try
                {
                    if (stringValue.Length == 0)
                    {
                        throw new FormatException($"Length of string number is 0");
                    }

                    for (int i = stringValue.Length - 1; i >= 0; i--)
                    {
                        while (stringValue[i] == ' ')
                        {
                            i--;

                            if (i == -1)
                            {
                                throw new FormatException("Number string is empty");
                            }
                        }

                        var currentChar = stringValue[i];
                        var currentDigit = (int)Char.GetNumericValue(stringValue[i]);

                        if (currentDigit == -1)
                        {
                            if (i == 0)
                            {
                                if (currentChar == '-')
                                {
                                    result *= -1;
                                }

                                break;
                            }
                            else
                            {
                                throw new FormatException($"{stringValue} is invalid number string");
                            }
                        }

                        sum = currentDigit * (int)Math.Pow(10, degree);
                        result += sum;
                        degree++;
                    }

                    return result;
                }
                catch (NullReferenceException e)
                {
                    throw new ArgumentNullException("stringValue argument is null", e);
                }
                catch (OverflowException)
                {
                    if (stringValue[0] == '-')
                    {
                        sum *= -1;
                        result *= -1;
                        double temp = result + sum;
                        double minValue = int.MinValue;

                        if (temp == minValue)
                        {
                            return int.MinValue;
                        }
                    }

                    throw;
                }
            }
        }
    }
}