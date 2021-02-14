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
        [TestCase(" ", "1", ExpectedResult = "1")]
        [TestCase("2", " ", ExpectedResult = "2")]
        [TestCase("3.5", "1", ExpectedResult = "1")]
        [TestCase("23", "0.5", ExpectedResult = "23")]
        [TestCase("-15", "7", ExpectedResult = "7")]
        [TestCase("8", "-1", ExpectedResult = "8")]
        [TestCase("-55", "-12", ExpectedResult = "0")]
        public string Sum_Returns_StringsSum(string num1, string num2)
        {
            return _stringSum.Sum(num1, num2);
        }
    }
}