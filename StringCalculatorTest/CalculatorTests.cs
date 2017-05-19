using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;
using System;

namespace StringCalculatorTest
{
    [TestClass]
    public class CalculatorTests
    {
        private Calculator calculator;

        public CalculatorTests()
        {
            calculator = new Calculator();
        }

        [TestMethod]
        public void EmptyStringReturnsZero()
        {
            Assert.AreEqual(0, calculator.Add(String.Empty));
        }
    }
}
