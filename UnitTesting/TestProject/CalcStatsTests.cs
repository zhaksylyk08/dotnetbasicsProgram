using Katas;
using NUnit.Framework;
using System;
using System.Linq;

namespace TestProject
{
    public class CalcStatsTests
    {
        private CalcStats _calcStats;
        private int[] _arr;

        [SetUp]
        public void SetUp()
        {
            _arr = new int[] { 6, 9, 15, -2, 92, 11 };

            _calcStats = new CalcStats(_arr);
        }

        [Test]
        public void CalcStats_NonEmptyArray()
        {
            int expectedMin = _arr.Min();
            int expectedMax = _arr.Max();
            int expectedNumberOfElements = _arr.Length;
            double expectedAverage = _arr.Average();

            Assert.AreEqual(expectedMin, _calcStats.Min);
            Assert.AreEqual(expectedMax, _calcStats.Max);
            Assert.AreEqual(expectedNumberOfElements, _calcStats.NumberOfElements);
            Assert.AreEqual(expectedAverage, _calcStats.Average);
        }
    }
}
