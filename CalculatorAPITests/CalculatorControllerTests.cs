using CalculatorAPI;
using NUnit.Framework;
using System;

namespace CalculatorAPITests
{
    public class CalculatorControllerTests
    {
        CalculatorController calculatorController;

        [SetUp]
        public void Setup()
        {
            calculatorController = new CalculatorController();
        }

        [Test]
        public void GivenTwoNumbers_ReturnsPercentagesOfTotal()
        {
            double[] actual = calculatorController.GetPercentagesOfTotal(5, 15);
            double[] expected = new double[]
            {
                25,
                75
            };
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(-3, 1)]
        [TestCase(4, -1)]
        [TestCase(-45, -9)]
        public void GivenNegativeNumber_ThrowsException(int a, int b)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => calculatorController.GetPercentagesOfTotal(a, b));
        }

        [Test]
        public void GivenTwoValuesOfZero_ReturnsArrayOfZeroes()
        {
            double[] expected = new double[] { 0, 0 };
            Assert.AreEqual(expected, calculatorController.GetPercentagesOfTotal(0, 0));
        }

        [Test]
        public void GivenOneValueOfZeroAndOneGreaterThanZero_ReturnsArrayWithOneValueOfOneAndTheOtherZero()
        {
            double[] expected = new double[] { 100, 0 };
            double[] expectedTwo = new double[] { 0, 100 };
            Assert.AreEqual(expected, calculatorController.GetPercentagesOfTotal(25, 0));
            Assert.AreEqual(expectedTwo, calculatorController.GetPercentagesOfTotal(0, 75));
        }
    }
}