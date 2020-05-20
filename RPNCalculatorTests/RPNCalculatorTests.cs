using ReversePolishNotationCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RPNCalculatorTests
{
    [TestClass]
    public class RPNCalculatorTests
    {

        [TestMethod]
        public void SimpleTest()
        {
            Assert.AreEqual(RPNCalculator.Calculate("2 1 + 3 *"), 9);
        }

        [TestMethod]
        public void MultipleDigitTest()
        {
            Assert.AreEqual(RPNCalculator.Calculate("21 3 *"), 63);
        }
        [TestMethod]
        public void ExtraSpacesTest()
        {
            Assert.AreEqual(RPNCalculator.Calculate("22    -22      +"), 0);
        }
        [TestMethod]
        public void NonIntegerResultTest()
        {
            Assert.AreEqual(RPNCalculator.Calculate("4 13  5 / +"), 6.6);
        }
        [TestMethod]
        public void TooManyOperandsTest()
        {
            Assert.AreEqual(RPNCalculator.Calculate("4 5 5 +"), double.MinValue);
        }

        [TestMethod]
        public void TooManyOperatorsTest()
        {
            Assert.AreEqual(RPNCalculator.Calculate("4 5 5 + + +"), double.MinValue);
        }
        [TestMethod]
        public void LongTest()
        {
            double result = RPNCalculator.Calculate("10 6 9 3 + -11 * / * 17 + 5 +");
            Assert.IsTrue(result > 21 && result < 22);
        }
    }
}

