using Katas;
using NUnit.Framework;

namespace TestProject
{
    public class Tests
    {
        private StringSum _stringSum;

        [SetUp]
        public void Setup()
        {
            _stringSum = new StringSum();
        }

        [TestCase(" ", " ", ExpectedResult = "0")]
        [TestCase(" ", "1", ExpectedResult = "0")]
        [TestCase("2", " ", ExpectedResult = "0")]
        public string Sum_Returns_StringsSum(string num1, string num2)
        {
            return _stringSum.Sum(num1, num2);
        }
    }
}