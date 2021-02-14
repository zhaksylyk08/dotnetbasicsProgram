using Katas;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestProject
{
    public class FizzBuzzTests
    {
        private FizzBuzz _fizzBuzz;
        private List<string> _numbers;
        private int _countOfNumbers;

        [SetUp]
        public void SetUp()
        {
            _fizzBuzz = new FizzBuzz();
            _numbers = _fizzBuzz.Print();
            _countOfNumbers = 100;
        }

        [Test]
        public void Print_Returns_HundredNumbers()
        {
            Assert.AreEqual(_countOfNumbers, _numbers.Count);
        }

        [Test]
        public void Print_Returns_Fizz()
        {
            var expected = "Fizz";

            for (int i = 3; i < 100; i += 3)
            {
                var number = FizzBuzzReturnsAt(i);
                Assert.AreEqual(expected, number);
            }
        }

        private string FizzBuzzReturnsAt(int num)
        {
            int index = num - 1;

            return _numbers[index];
        }
    }
}
