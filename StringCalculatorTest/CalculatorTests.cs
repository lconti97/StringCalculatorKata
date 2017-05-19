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

        [TestMethod]
        public void OneReturnsOne()
        {
            Assert.AreEqual(1, calculator.Add("1"));
        }

        [TestMethod]
        public void OneTwoReturnsThree()
        {
            Assert.AreEqual(3, calculator.Add("1,2"));
        }

        [TestMethod]
        public void OneTwoThreeReturnsSix()
        {
            Assert.AreEqual(6, calculator.Add("1,2,3"));
        }

        [TestMethod]
        public void NewLinesAsDelimitersIsOk()
        {
            Assert.AreEqual(6, calculator.Add("1\n2,3"));
        }

        [TestMethod]
        public void NewLinesAsDelimitersIsOkPartTwo()
        {
            Assert.AreEqual(6, calculator.Add("1,2\n3"));
        }

        [TestMethod]
        public void CustomDelimitersWork()
        {
            Assert.AreEqual(3, calculator.Add("//;\n1;2"));
        }

        [TestMethod]
        public void AddingANegativeNumberThrowsException()
        {
            var exception = Assert.ThrowsException<NegativeNumberException>(() => calculator.Add("1,-2"));
            Assert.AreEqual("-2 is not allowed.", exception.Message);
        }

        [TestMethod]
        public void AddingMultipleNegativeNumbersThrowsException()
        {
            var exception = Assert.ThrowsException<NegativeNumberException>(() => calculator.Add("-1,-2"));
            Assert.AreEqual("-1, -2 are not allowed.", exception.Message);
        }

        [TestMethod]
        public void NumbersLargerThan1000AreIgnored()
        {
            Assert.AreEqual(2, calculator.Add("2,1001"));
        }

        [TestMethod]
        public void DelimitersCanBeOfAnyLength()
        {
            Assert.AreEqual(6, calculator.Add("//[***]\n1***2***3"));
        }
    }
}
