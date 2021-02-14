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
                if (i % 5 != 0)
                {
                    var number = PrintReturnsAt(i);
                    Assert.AreEqual(expected, number);
                }
            }
        }

        [Test]
        public void Print_Returns_Buzz()
        {
            var expected = "Buzz";

            for (int i = 5; i <= 100; i += 5)
            {
                if (i % 3 != 0)
                {
                    var number = PrintReturnsAt(i);
                    Assert.AreEqual(expected, number);
                }
            }
        }

        [TestCase(15)]
        [TestCase(45)]
        [TestCase(75)]
        public void Print_Returns_FizzBuzz(int num)
        {
            var expected = "FizzBuzz";

            Assert.AreEqual(expected, PrintReturnsAt(num));
        }

        private string PrintReturnsAt(int num)
        {
            int index = num - 1;

            return _numbers[index];
        }
    }
}
