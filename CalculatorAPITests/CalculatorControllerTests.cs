using CalculatorAPI;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace CalculatorAPITests
{
    [TestFixture]
    class CalculatorControllerTests
    {
        CalculatorController calculatorController;

        [SetUp]
        public void SetUp()
        {
            calculatorController = new CalculatorController();
        }

        [Test]
        public void GivenTwoNonNegativeNumbers_ReturnsOkHTTPCode()
        {
            var resultOfTwoPositives = calculatorController.GetPercentagesOfTotal(1, 2);
            var resultOfTwoZeroes = calculatorController.GetPercentagesOfTotal(0, 0);
            var resultOfOneZeroOnePositive = calculatorController.GetPercentagesOfTotal(0, 1);
            Assert.AreEqual(typeof(OkObjectResult), resultOfTwoPositives.Result.GetType());
            Assert.AreEqual(typeof(OkObjectResult), resultOfTwoZeroes.Result.GetType());
            Assert.AreEqual(typeof(OkObjectResult), resultOfOneZeroOnePositive.Result.GetType());
        }

        [Test]
        public void GivenANegativeNumber_ReturnsBadRequestHTTPCode()
        {
            var resultOfOneNegative = calculatorController.GetPercentagesOfTotal(1, -2);
            var resultOfTwoNegatives = calculatorController.GetPercentagesOfTotal(-2, -2);
            Assert.AreEqual(typeof(BadRequestResult), resultOfOneNegative.Result.GetType());
            Assert.AreEqual(typeof(BadRequestResult), resultOfTwoNegatives.Result.GetType());
        }
    }
}
