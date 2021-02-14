using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katas
{
    public class CalcStats
    {
        private int[] _numbers;
        public int Min { get; private set; }

        public int Max { get; private set; }

        public double Average { get; private set; }

        public int NumberOfElements { get; private set; }

        public CalcStats(int[] numbers)
        {
            if (numbers.Length == 0)
            {
                throw new ArgumentException("Array is empty");
            }

            _numbers = numbers;

            Min = _numbers.Min();
            Max = _numbers.Max();
            Average = _numbers.Average();
            NumberOfElements = _numbers.Length;
        }
    }
}
